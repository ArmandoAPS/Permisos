<template>
  <div>
    <h2>Tipos de Permiso</h2>
    <b-button v-b-modal.modal-prevent-closing>Nuevo Tipo de Permiso</b-button>
    <b-table striped hover :items="list">
      <template v-slot:cell(id)="data">
        {{ data.value }}
      </template>
      <template v-slot:cell(descripcion)="data">
        {{ data.value }}
      </template>  
      <template v-slot:cell(actions)="row">
        <b-button size="sm" class="mr-1">
          Info modal
        </b-button>
        <b-button size="sm" >
          {{ row.detailsShowing ? 'Hide' : 'Show' }} Details
        </b-button>
      </template>
      
    </b-table>
    <b-modal
      id="modal-prevent-closing"
      ref="modal"
      :title="title"
      @show="resetModal"
      @hidden="resetModal"
      @ok="handleOk"
    >
      <form ref="form" @submit.stop.prevent="handleSubmit">
        <b-form-group
          :state="descripcionState"
          label="Descripción"
          label-for="name-input"
          invalid-feedback="La descripción es requerida"
        >
          <b-form-input
            id="name-input"
            v-model="descripcion"
            :state="descripcionState"
            required
          ></b-form-input>
        </b-form-group>
      </form>
    </b-modal>
  </div>
</template>

<script>
  export default {
    data() {
      return {
        id: 0,
        title: "Nuevo Tipo de Permiso",
        descripcion:'',
        descripcionState: null,
      }
    },
    async created() {
      await this.refresh();
    },
    computed: {
      list() {
        return this.$store.state.tipos.list;
      }
    },
    methods: {
      async refresh() {
         await this.$store.dispatch({ type: "tipos/load"});
      },
      edit(data) {
        this.id = data.id;
        this.descripcion = data.descripcion;
        this.$bvModal.show('modal-prevent-closing')        
      },
      checkFormValidity() {
        const valid = this.$refs.form.checkValidity()
        this.descripcionState = valid
        return valid
      },
      resetModal() {
        this.descripcion = ''
        this.descripcionState = null
      },
      handleOk(bvModalEvt) {
        // Prevent modal from closing
        bvModalEvt.preventDefault()
        // Trigger submit handler
        this.handleSubmit()
      },
      async handleSubmit() {
        // Exit when the form isn't valid
        if (!this.checkFormValidity()) {
          return
        }
        // Push the name to submitted names
        await this.$store.dispatch({ type: "tipos/create", data: this.descripcion });
        await this.refresh();
        // Hide the modal manually
        this.$nextTick(() => {
          
          this.$bvModal.hide('modal-prevent-closing')
        })
      }               
    }
  }
</script>
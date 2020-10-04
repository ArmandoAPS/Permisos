<template>
  <div>
    <h2>Solicitudes de Permiso</h2>
    <b-button v-b-modal.modal-prevent-closing>Nueva Solicitud de Permiso</b-button>
    <b-table striped hover :items="list" :fields="fields">

      <template v-slot:cell()="data">
        {{ data.value }}
      </template>

      <template v-slot:cell(acciones)="row">
        <b-button size="sm" class="mr-2" @click="edit(row)">Editar</b-button>
        <b-button size="sm" class="mr-2" @click="del(row)">Eliminar</b-button>
      </template>      
    </b-table>
    <b-modal
      id="modal-prevent-closing"
      ref="modal"
      :title="title"
      
      @hidden="resetModal"
      @ok="handleOk"
    >
      <form ref="form" @submit.stop.prevent="handleSubmit">
        <b-form-group
          :state="nombreState"
          label="Nombre Empleado"
          label-for="nombre"
          invalid-feedback="El nombre es requerido."
        >
          <b-form-input
            id="nombre"
            v-model="nombre"
            :state="nombreState"
            required
          ></b-form-input>
        </b-form-group>
        <b-form-group
          :state="apellidosState"
          label="Apellidos Empleado"
          label-for="apellidos"
          invalid-feedback="Los apellidos son requerido."
        >
          <b-form-input
            id="apellidos"
            v-model="apellidos"
            :state="apellidosState"
            required
          ></b-form-input>
        </b-form-group>
        <b-form-group
          :state="tipoState"
          label="Tipo Permiso"
          label-for="tipo"
          invalid-feedback="El tipo de permiso es requerido."
        >
        <b-form-select v-model="tipo" :options="tipos"
          value-field="id"
          text-field="descripcion"
        ></b-form-select>
        </b-form-group>
        <b-form-group
          :state="fechaState"
          label="Fecha Permiso"
          label-for="fecha"
          invalid-feedback="La fecha de permiso es requerida."
        >
        <b-form-datepicker v-model="fecha" :min="minFecha" locale="es"></b-form-datepicker>
        </b-form-group>                          
      </form>
    </b-modal>
      <b-modal id="modal-confirm" title="Eliminar Solicitud de Permiso" @ok="handleDelete">
    <p class="my-4">¿Desea eliminar la solicitud de permiso?</p>
  </b-modal>
  </div>
</template>

<script>
  export default {
    data() {
      return {
        id: 0,
        
        nombre:'',
        apellidos: '',
        tipo:0,
        minFecha:new Date(),
        fecha: new Date(),
        nombreState: null,
        apellidosState: null,
        tipoState: null,
        fechaState:null,
        fields:["id","nombreEmpleado","apellidosEmpleado",
        { key: "tipoPermiso.descripcion", label: "Tipo Permiso"}, 
        "fechaPermiso", "acciones"]
      }
    },
    async created() {
      await this.refresh();
    },
    computed: {
      list() {
        return this.$store.state.permisos.list;
      },
      tipos() {
        return this.$store.state.tipos.list;
      }, 
      title() { return this.id == 0 ? "Nueva Solicitud de Permiso" : "Editar Solicitud de Permiso"; }    
    },
    methods: {
      async refresh() {
        await this.$store.dispatch({ type: "tipos/load"});
        await this.$store.dispatch({ type: "permisos/load"});
      },
      edit(data) {
        this.id = data.item.id;
        this.nombre = data.item.nombreEmpleado;
        this.apellidos = data.item.apellidosEmpleado;
        this.tipo = data.item.tipoPermiso.id;
        this.fecha = data.item.fechaPermiso;
        this.$bvModal.show('modal-prevent-closing')        
      },
      del(data) {
        this.id = data.item.id;
        console.log(this.id)
        this.$bvModal.show('modal-confirm');
      },
      checkFormValidity() {
        const valid = this.$refs.form.checkValidity()
        this.nombreState = valid
        this.apellidosState = valid;
        this.tipoState = valid;
        this.fechaState = valid;
        return valid
      },
      resetModal() {
        this.id = 0
        this.nombre = ''
        this.nombreState = null
        this.apellidos = ''
        this.apellidosState = null
        this.tipo = ''
        this.tipoState = null
        this.fecha = new Date()
        this.fechaState = null                    
      },
      async handleDelete(bvModalEvt)
      {
        bvModalEvt.preventDefault()
        await this.$store.dispatch( { type: "permisos/delete", data: this.id });
        await this.refresh();
        this.$nextTick(() => {
          this.$bvModal.hide('modal-confirm')
        })
      },
      handleOk(bvModalEvt) {
        bvModalEvt.preventDefault()
        this.handleSubmit()
      },
      async handleSubmit() {

        if (!this.checkFormValidity()) {
          return
        }


        await this.$store.dispatch(
          { 
            type: this.id == 0 ? "permisos/create" : "permisos/update", 
            data: { 
                id: this.id,
                nombreEmpleado: this.nombre, 
                apellidosEmpleado: this.apellidos, 
                tipoPermisoId: this.tipo,
                fechaPermiso: this.fecha
              }
        });

        await this.refresh();
        // Hide the modal manually
        this.$nextTick(() => {
          
          this.$bvModal.hide('modal-prevent-closing')
        })
      }               
    }
  }
</script>
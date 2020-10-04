<template>
    <div>
      <b-navbar toggleable="lg" type="dark" variant="success">
        <b-container>
            <b-navbar-brand href="/">Empresa X: Solicitudes de Permisos</b-navbar-brand>
            <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>
            <b-collapse id="nav-collapse" is-nav>
              <!-- Right aligned nav items -->
              <b-navbar-nav class="ml-auto">
                <b-button 
                    size="sm" 
                    class="my-2 mx-2"
                    type="button" 
                    to="/permisos"
                    >Permisos</b-button>                  
                <b-button 
                    size="sm" 
                    class="my-2 mx-2"
                    type="button" 
                    to="/tipos"
                    >Tipos</b-button>

              </b-navbar-nav>
            </b-collapse>
          </b-container>
      </b-navbar>
    </div>  
</template>
import Vue from 'vue'
import Vuex from 'vuex'
import tipos from './modules/tipos'
import permisos from './modules/permisos'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
  },
  mutations: {
  },
  actions: {
  },
  modules: {
    tipos,
    permisos
  }
})

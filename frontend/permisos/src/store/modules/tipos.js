import axios from 'axios'

export default {
    namespaced: true,
    state: {
        dummy:0,
        list:[]
    },
    actions: {
        async load({commit}) {
            let resp = await axios.get('http://localhost:51510/api/tipopermisos')
            commit('setList', resp.data);
                       
        },
        async create({state},payload) {
            let resp = await axios
                .post('http://localhost:51510/api/tipopermisos', { descripcion: payload.data } );
            state.list.push(resp.data)
        }   
    },
    mutations: {
        setList(state, data)
        {
            state.list = data;
        }
    }
}
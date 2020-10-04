import axios from 'axios'

export default {
    namespaced: true,
    state: {
        list:[]
    },
    actions: {
        async load({commit}) {
            let resp = await axios.get('http://localhost:51510/api/permisos')
            commit('setList', resp.data);
                       
        },
        async create({state},payload) {
            let resp = await axios
                .post('http://localhost:51510/api/permisos', payload.data );
            state.list.push(resp.data)
        },
        async update({state},payload) {
            await axios
                .put('http://localhost:51510/api/permisos/' + payload.data.id, payload.data );
            console.log(state.list)
        },
        async delete({state},payload) {
            await axios
                .delete('http://localhost:51510/api/permisos/' + payload.data );
            console.log(state.list)
        }                     
        
    },
    mutations: {
        setList(state, data)
        {
            state.list = data;
        }
    }
}

import Vuex from 'vuex'
import uiModule from './ui';

const store = new Vuex.Store({
    modules: {
        ui: uiModule
    }
});

export default store;
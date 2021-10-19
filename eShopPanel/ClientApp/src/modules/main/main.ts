import { Vue, Component } from 'vue-property-decorator';
import Header from './header/header.vue';

@Component({
    components: {
        'app-header': Header
    },
})
export default class Main extends Vue {
    
}
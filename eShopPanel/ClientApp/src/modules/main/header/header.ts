import { Vue } from 'vue-property-decorator';

export default class Header extends Vue {
    public onToggleMenuSidebar(): void {
        this.$emit('toggle-menu-sidebar');
    }
}
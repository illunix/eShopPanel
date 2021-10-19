import { Vue, Component } from 'vue-property-decorator';
import Vuelidate from 'vuelidate';
import { email, required } from 'vuelidate/lib/validators';

Vue.use(Vuelidate);

@Component({
    validations: {
        email: {
            email,
            required
        },
        password: {
            required
        }
    }
})
export default class SignIn extends Vue {
    public email: string = '';
    public password: string = '';
    public signInSubmitted: boolean = false;
    public invalidCredentials: boolean = false;

    public async signIn(): Promise<void> {
        this.signInSubmitted = true;

        const credentials = {
            email: this.email,
            password: this.password
        };

        this.$http.post('/api/panel/sign-in', credentials)
            .then(response => {
                console.log('logged');
                // this.$router.push('/panel/dashboard');
            })
            .catch(() => {
                this.invalidCredentials = true;
            })
    }
}

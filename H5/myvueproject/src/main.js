import Vue from 'vue'
import App from './App.vue'
import axios from 'axios'
//import VueAxios from 'vue-axios'
import ElementUI from 'element-ui'
import 'element-ui/lib/theme-chalk/index.css'
Vue.use(ElementUI)

Vue.prototype.$axios = axios    //全局注册，使用方法为:this.$axios
Vue.config.productionTip = false
//Vue.use(VueAxios, axios)
new Vue({
  render: h => h(App),
}).$mount('#app')

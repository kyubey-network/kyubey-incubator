import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'
import router from './router/index'
import store from './store'
import { sync } from 'vuex-router-sync'
import App from 'components/app-root'
import { FontAwesomeIcon } from './icons'
import 'bootstrap'
import Element from 'element-ui'
import 'element-ui/lib/theme-chalk/index.css'
// Registration of global components
Vue.component('icon', FontAwesomeIcon)
Vue.use(Vuex)
Vue.use(Element)
Vue.prototype.$http = axios

sync(store, router)

const app = new Vue({
  store,
  router,
  ...App
})

export {
  app,
  router,
  store
}

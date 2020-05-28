import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import "bootstrap";
import VueSidebarMenu from "vue-sidebar-menu";
import "vue-sidebar-menu/dist/vue-sidebar-menu.css";
import "@fortawesome/fontawesome-free/css/all.css";
import "@fortawesome/fontawesome-free/js/all.js";
import VueFloatLabel from "vue-float-label";
import ToggleButton from "vue-js-toggle-button";
import VueCurrencyInput from "vue-currency-input";

Vue.use(VueCurrencyInput);

Vue.use(ToggleButton);

Vue.use(VueFloatLabel);

Vue.use(VueSidebarMenu);

Vue.config.productionTip = false;

new Vue({
  router,
  render: (h) => h(App),
}).$mount("#app");

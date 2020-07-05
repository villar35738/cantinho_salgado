import Vue from "vue";
import Router from "vue-router";
import Estoque from "./components/Estoque/Estoque";
import Produto from "./components/Estoque/Produto";
import NovaComanda from "./components/Vendas/NovaComanda";
import Comandas from "./components/Vendas/Comandas";
import Report from "./components/Relatorios/Relatorio";

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: "/estoque",
      nome: "Estoque",
      component: Estoque,
    },
    {
      path: "/produtos",
      nome: "Produtos",
      component: Produto,
    },
    {
      path: "/novacomanda",
      nome: "Nova Comanda",
      component: NovaComanda,
    },
    {
      path: "/comandas",
      nome: "Comandas Abertas",
      component: Comandas,
    },
    {
      path: "/relatorios",
      nome: "Relatorios",
      component: Report,
    },
  ],
});

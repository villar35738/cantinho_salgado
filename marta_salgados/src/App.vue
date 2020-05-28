<template>
  <div id="demo" :class="[{ collapsed: collapsed }, { onmobile: isOnMobile }]">
    <div class="demo">
      <div class="container">
        <router-view />
      </div>
      <sidebar-menu
        :menu="menu"
        :collapsed="collapsed"
        :show-one-child="true"
        @toggle-collapse="onToggleCollapse"
      />
      <div
        v-if="isOnMobile && !collapsed"
        class="sidebar-overlay"
        @click="collapsed = true"
      />
    </div>
  </div>
</template>

<script>
export default {
  components: {},
  data() {
    return {
      menu: [
        {
          header: true,
          title: "Cantinho do Salgado",
          hiddenOnCollapse: true,
        },
        {
          // href: "/vendas",
          title: "Vendas",
          icon: "fas fa-shopping-bag",
          child: [
            {
              href: "/novacomanda",
              title: "Nova comanda",
              badge: {
                text: "NEW",
                class: "badge badge-primary",
              },
            },
            {
              href: "/comandas",
              title: "Comandas abertas",
              badge: {
                text: "OPENED",
                class: "badge badge-success",
              },
            },
          ],
        },
        {
          header: true,
          title: "Estoque",
          hiddenOnCollapse: true,
        },
        {
          href: "/estoque",
          title: "Gestão de estoque",
          icon: "fas fa-warehouse",
        },
        {
          href: "/produtos",
          title: "Cadastrar produtos",
          icon: "fas fa-drumstick-bite",
        },
        {
          header: true,
          title: "Relatorios",
          hiddenOnCollapse: true,
        },
        {
          href: "/relatorios",
          title: "Relatorios",
          icon: "fas fa-chart-pie",
        },
      ],
      collapsed: false,
      isOnMobile: false,
    };
  },
  mounted() {
    this.onResize();
    window.addEventListener("resize", this.onResize);
  },
  methods: {
    onToggleCollapse(collapsed) {
      console.log(collapsed);
      this.collapsed = collapsed;
    },
    // onItemClick(event, item) {
    //   console.log("onItemClick");
    //   // console.log(event)
    //   // console.log(item)
    // },
    onResize() {
      if (window.innerWidth <= 767) {
        this.isOnMobile = true;
        this.collapsed = true;
      } else {
        this.isOnMobile = false;
        this.collapsed = false;
      }
    },
  },
};
</script>

<style lang="scss">
@import "~bootstrap/dist/css/bootstrap.css";
@import url("https://fonts.googleapis.com/css?family=Source+Sans+Pro:400,600");

body,
html {
  margin: 0;
  padding: 0;
}

td {
  vertical-align: middle !important;
}

.textCenter {
  text-align: center;
}

body {
  font-family: "Source Sans Pro", sans-serif;
  font-size: 18px;
  background-color: #f2f4f7;
  color: #262626;
}

#demo {
  padding-left: 350px;
  transition: 0.3s ease;
}
#demo.collapsed {
  padding-left: 50px;
}
#demo.onmobile {
  padding-left: 50px;
}

.sidebar-overlay {
  position: fixed;
  width: 100%;
  height: 100%;
  top: 0;
  left: 0;
  background-color: #000;
  opacity: 0.5;
  z-index: 900;
}

.demo {
  padding: 30px;
}

.container {
  max-width: 900px;
}

// pre {
//   font-family: Consolas, monospace;
//   color: #000;
//   background: #fff;
//   border-radius: 2px;
//   padding: 15px;
//   line-height: 1.5;
//   overflow: auto;
// }
</style>

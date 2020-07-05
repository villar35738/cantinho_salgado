<template>
  <div>
    <Titulo texto="Comandas abertas" />

    <div class="row">
      <table class="table table-bordered table-hover">
        <thead class="thead-dark">
          <tr>
            <th style="width: 30%">Nome do cliente</th>
            <th class="textCenter" style="width: 20%">Tipo venda</th>
            <th class="textCenter" style="width: 30%">Pedido</th>
            <th class="textCenter" style="width: 29%">Opções</th>
          </tr>
        </thead>

        <tbody v-if="comandas != ''">
          <tr v-for="comanda in comandas" :key="comanda.ID">
            <td>{{ comanda.NomeCliente }}</td>
            <td style="text-align: center">
              {{ comanda.TipoVenda }} <br />
              {{ comanda.DataEncomenda }} <br />
              {{ comanda.TelefoneCliente }}
            </td>
            <td class="textCenter">
              <p v-for="(item, index) in comanda.Pedido" :key="index">
                {{ item.Nome }} : {{ item.Qtd }}
              </p>
            </td>
            <td class="textCenter">
              <button
                class="btn btn-success"
                @click="concluirComanda(comanda)"
                style="margin-right: 2%"
              >
                <i class="fas fa-check"></i>
              </button>
              <button class="btn btn-danger" @click="cancelarComanda(comanda)">
                <i class="fas fa-window-close"></i>
              </button>
            </td>
          </tr>
        </tbody>
        <tfoot v-else>
          <tr>
            <td colspan="3" style="text-align: center">
              <h5>
                Nenhuma comanda aberta
              </h5>
            </td>
          </tr>
        </tfoot>
      </table>
    </div>
  </div>
</template>

<script>
import Titulo from "../_share/Titulo";

export default {
  components: {
    Titulo,
  },
  data() {
    return {
      comandas: [
        {
          ID: 1,
          NomeCliente: "Anderson",
          TipoVenda: "Balcão",
          DataEncomenda: "",
          TelefoneCliente: "",
          Pedido: [
            {
              Nome: "Coxinha",
              Qtd: 5,
            },
            {
              Nome: "Salsicha",
              Qtd: 10,
            },
          ],
        },
        {
          ID: 2,
          NomeCliente: "Vinicius",
          TipoVenda: "Encomenda",
          DataEncomenda: "25/05/2020",
          TelefoneCliente: "19 999695502",
          Pedido: [
            {
              Nome: "Coxinha",
              Qtd: 2,
            },
            {
              Nome: "Salsicha",
              Qtd: 5,
            },
            {
              Nome: "Presunto e queijo",
              Qtd: 10,
            },
          ],
        },
      ],
    };
  },
  methods: {
    concluirComanda(comanda) {
      let indice = this.comandas.indexOf(comanda);
      this.comandas.splice(indice, 1);
    },
    cancelarComanda(comanda) {
      let indice = this.comandas.indexOf(comanda);
      this.comandas.splice(indice, 1);
    },
  },
};
</script>

<style scoped></style>

<template>
  <div>
    <Titulo texto="Nova comanda" />
    <div class="row">
      <float-label>
        <input
          type="text"
          class="form-control"
          placeholder="Nome do cliente"
          v-model="inputCliente"
        />
      </float-label>
      <toggle-button
        style="margin-left: 1%;"
        v-model="inputVendaBalcao"
        :width="150"
        :height="40"
        :font-size="15"
        :value="true"
        :sync="true"
        :labels="{ checked: 'Venda balcão', unchecked: 'Encomenda' }"
        :color="{ checked: '#75c791', unchecked: '#ff7100' }"
      />
    </div>

    <div class="row" style="margin-top:2%" v-show="inputVendaBalcao != true">
      <float-label label="Data da encomenda" fixed>
        <input
          type="date"
          class="form-control"
          placeholder=""
          v-model="inputDataEncomenda"
        />
      </float-label>

      <VuePhoneNumberInput
        style="margin-left: 1%;"
        v-model="inputTelefoneCliente"
        :no-country-selector="countrySelector"
        :translations="translations"
      />
    </div>

    <div class="row" style="margin-top:2%">
      <float-label label="Lista de produtos" fixed style="width: 65%">
        <select class="custom-select" v-model="inputProdutoSelecionado">
          <option
            v-for="produto in produtos"
            :key="produto.ID"
            v-bind:value="produto"
          >
            {{ produto.nome }}
          </option>
        </select>
      </float-label>
      <float-label style="width: 20%">
        <input
          type="number"
          class="form-control"
          placeholder="Quantidade"
          v-model="inputQtd"
          min="0"
        />
      </float-label>
      <button
        class="btn btn-primary"
        style="width: 14%; margin-left: 1%"
        @click="addProduto()"
      >
        <i class="fas fa-plus"></i>
      </button>
    </div>

    <div class="row">
      <table class="table table-bordered table-hover">
        <thead class="thead-dark">
          <tr>
            <th style="width: 66%">Nome do produto</th>
            <th class="textCenter" style="width: 20%">Quantidade</th>
            <th class="textCenter" style="width: 14%">Opções</th>
          </tr>
        </thead>

        <tbody v-if="produtosSelecionados != ''">
          <tr v-for="produto in produtosSelecionados" :key="produto.ID">
            <td>{{ produto.Nome }}</td>
            <td class="textCenter">{{ produto.QTD }}</td>
            <td>
              <button class="btn btn-danger" @click="deletarProduto(produto)">
                DELETAR
              </button>
            </td>
          </tr>
        </tbody>
        <tfoot v-else>
          <tr>
            <td colspan="3" style="text-align: center">
              <h5>
                Nenhum produto adicionado a comanda
              </h5>
            </td>
          </tr>
        </tfoot>
      </table>
    </div>

    <div
      class="row"
      style="float: right"
      v-show="
        (produtosSelecionados != '' &&
          inputVendaBalcao == true &&
          inputCliente != '') ||
          (inputVendaBalcao == false &&
            inputCliente != '' &&
            inputTelefoneCliente != null &&
            inputDataEncomenda != '' &&
            produtosSelecionados != '')
      "
    >
      <button class="btn btn-success" @click="addProduto()">
        Enviar comanda <i class="far fa-check-circle"></i>
      </button>
    </div>
  </div>
</template>

<script>
import Titulo from "../_share/Titulo";

import VuePhoneNumberInput from "vue-phone-number-input";
import "vue-phone-number-input/dist/vue-phone-number-input.css";

export default {
  components: {
    Titulo,
    VuePhoneNumberInput,
  },
  props: {},
  data() {
    return {
      inputCliente: "",
      inputTelefoneCliente: "",
      inputDataEncomenda: "",
      inputVendaBalcao: true,
      inputQtd: "",
      inputProdutoSelecionado: {},
      produtos: [
        { ID: 1, nome: "Coxinha de Frango" },
        { ID: 2, nome: "Salsicha empanada" },
        { ID: 3, nome: "Enrolado de presunto e queijo" },
      ],
      produtosSelecionados: [],
      countrySelector: true,
      translations: {
        phoneNumberLabel: "Número de telefone",
      },
    };
  },
  methods: {
    addProduto() {
      let _produto = {
        ID: this.inputProdutoSelecionado.ID,
        Nome: this.inputProdutoSelecionado.nome,
        QTD: this.inputQtd,
      };

      this.produtosSelecionados.push(_produto);
      this.inputProdutoSelecionado = "";
      this.inputQtd = "";
    },
    deletarProduto(produto) {
      let indice = this.produtosSelecionados.indexOf(produto);
      this.produtosSelecionados.splice(indice, 1);
    },
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.row {
  padding-top: 10px;
}

float-label {
  margin-right: 30px;
}
</style>

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
        :translations="translations"
        :default-country-code="defaultCountry"
        :only-countries="onlyCountries"
      />
    </div>

    <div class="row" style="margin-top:2%">
      <float-label label="Lista de produtos" fixed style="width: 65%">
        <multiselect
          v-model="inputProdutoSelecionado"
          deselect-label="Can't remove this value"
          track-by="estoqueID"
          label="produtoNome"
          placeholder="Select one"
          selectLabel=""
          :options="produtos"
          :searchable="false"
          :allow-empty="false"
        >
        </multiselect>
        <!-- <select class="custom-select" v-model="inputProdutoSelecionado">
          <option
            v-for="produto in produtos"
            :key="produto.estoqueID"
            v-bind:value="produto"
          >
            <label>
              {{ produto.produtoNome }}
            </label>
            <label style="float: right">
              Estoque: {{ produto.qtdEstoque }}
            </label>
          </option>
        </select> -->
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
import Multiselect from "vue-multiselect";
import "vue-multiselect/dist/vue-multiselect.min.css";

export default {
  components: {
    Titulo,
    VuePhoneNumberInput,
    Multiselect,
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
      produtos: [],
      produtosSelecionados: [],
      countrySelector: true,
      translations: {
        phoneNumberLabel: "Número de telefone",
      },
      defaultCountry: "BR",
      onlyCountries: ["BR"],
    };
  },
  methods: {
    carregarEstoque() {
      this.$http
        .get(`http://localhost:5000/estoque/${true}`)
        .then((res) => res.json())
        .then((produtos) => {
          this.produtos = produtos;
        });
    },
    addProduto() {
      let _produto = {
        ID: this.inputProdutoSelecionado.estoqueID,
        Nome: this.inputProdutoSelecionado.produtoNome,
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
    enviarComanda() {
      let _comanda = {
        NomeCliente: this.inputCliente,
        Encomenda: this.inputVendaBalcao,
        DataEncomenda: this.inputDataEncomenda,
        TelefoneCliente: this.TelefoneCliente,
      };

      // let _comandaItens = {

      // };

      this.$http
        .post("http://localhost:5000/produto", _comanda)
        .then((res) => res.json())
        .then(
          (this.NomeCliente = ""),
          (this.inputVendaBalcao = true),
          (this.inputTelefoneCliente = ""),
          (this.inputDataEncomenda = "")
        );
    },
  },
  created() {
    this.carregarEstoque();
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

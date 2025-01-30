import axios from "axios";

const apiAnuncio = axios.create({
    baseURL: "https://localhost:7233/api/v1/anuncio",
  });

const apiProduto = axios.create({
  baseURL: "https://localhost:7233/api/v1/produto",
});


export const criarAnuncio = async (dados) => {
  try {
    const response = await apiAnuncio.post("", dados);
    return response.data;
  } catch (error) {
    console.error("Erro ao conectar com a API:", error);
    throw error;
  }
};

export const criarProduto = async (dados) => {
    try {
      const response = await apiProduto.post("", dados);
      return response.data;
    } catch (error) {
      console.error("Erro ao conectar com a API:", error);
      throw error;
    }
  };

export default {apiAnuncio, apiProduto};
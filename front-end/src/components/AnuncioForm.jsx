import React, { useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import { criarAnuncio, criarProduto } from "../services/api";


const AdForm = () => {
  const [isProduct, setIsProduct] = useState(false);
  const [message, setMessage] = useState("");
  const [errors, setErrors] = useState({});

  const [formData, setFormData] = useState({
    Nome: "",
    DataPublicacao: "",
    Valor: "",
    Cidade: "",
    Categoria: "",
    Modelo: "",
    Condicao: "",
    Quantidade: "",
  });

  const Limprar = () => {
    setFormData({
      Nome: "",
      DataPublicacao: "",
      Valor: "",
      Cidade: "",
      Categoria: "",
      Modelo: "",
      Condicao: "",
      Quantidade: "",
    });
    setIsProduct(false);
    setErrors({});
    setMessage("");
  };
  

  const validateField = (name, value) => {
    let error = "";

    switch (name) {
      case "Nome":
        if (!value || value.length < 5) error = "O nome do anúncio deve ter pelo menos 5 caracteres.";
        break;
      case "DataPublicacao":
        if (!value) {
          error = "A data de publicação é obrigatória.";
        } else {
            const today = new Date();
            const formattedDate = today.getFullYear() + '-' + (today.getMonth() + 1).toString().padStart(2, '0') + '-' + today.getDate().toString().padStart(2, '0');
          if (value < formattedDate) error = "A data de publicação não pode ser anterior à data de hoje.";
        }
        break;
      case "Valor":
        if (!value || value < 1) error = "O valor deve ser maior ou igual a R$ 1,00.";
        break;
      case "Cidade":
        if (!value) error = "Selecione uma cidade válida.";
        break;
      case "Categoria":
        if (isProduct && !value) error = "Selecione uma categoria válida.";
        break;
      case "Modelo":
        if (isProduct && !value) error = "Selecione um modelo válido.";
        break;
      case "Condicao":
        if (isProduct && !value) error = "Selecione uma condição válida para o produto.";
        break;
      case "Quantidade":
        if (isProduct && (!value || value < 1)) error = "A quantidade deve ser no mínimo 1 unidade.";
        break;
      default:
        break;
    }

    return error;
  };

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });

    // Atualizar os erros em tempo real
    setErrors((prevErrors) => ({
      ...prevErrors,
      [name]: validateField(name, value),
    }));
  };

  const validateForm = () => {
    let newErrors = {};
    Object.keys(formData).forEach((key) => {
      const error = validateField(key, formData[key]);
      if (error) newErrors[key] = error;
    });

    setErrors(newErrors);
    return Object.keys(newErrors).length === 0;
  };

  const FormularioSubmit = async (e) => {
    e.preventDefault();

    if (!validateForm()) {
      setMessage("Corrija os erros antes de enviar.");
      return;
    }

    try {
      if (isProduct) {
        await criarProduto(formData);
      } else {
        await criarAnuncio(formData);
      }
      setMessage("Cadastro realizado com sucesso!");
      setFormData({
        Nome: "",
        DataPublicacao: "",
        Valor: "",
        Cidade: "",
        Categoria: "",
        Modelo: "",
        Condicao: "",
        Quantidade: "",
      });
      setErrors({});
    } catch (error) {
      setMessage("Erro ao enviar. Tente novamente.");
    }
  };

  return (
    <div className="container mt-5">
      <h2 className="mb-4">Criar {isProduct ? "Produto" : "Anúncio"}</h2>
      {message && <div className="alert alert-info">{message}</div>}
      
      <div className="mb-3">
        <label className="form-label">Marcar como Produto</label>
        <div className="form-check form-switch">
          <input
            className="form-check-input"
            type="checkbox"
            checked={isProduct}
            onChange={() => setIsProduct(!isProduct)}
          />
        </div>
      </div>

      <form onSubmit={FormularioSubmit} className="border p-4 rounded bg-light">
        <div className="mb-3">
          <label className="form-label">Nome do Anúncio</label>
          <input type="text" name="Nome" className="form-control" value={formData.Nome} onChange={handleChange} />
          {errors.Nome && <div className="text-danger">{errors.Nome}</div>}
        </div>

        <div className="mb-3">
          <label className="form-label">Data de Publicação</label>
          <input type="date" name="DataPublicacao" className="form-control" value={formData.DataPublicacao} onChange={handleChange} />
          {errors.DataPublicacao && <div className="text-danger">{errors.DataPublicacao}</div>}
        </div>

        <div className="mb-3">
          <label className="form-label">Valor (R$)</label>
          <input type="number" name="Valor" className="form-control" value={formData.Valor} onChange={handleChange} />
          {errors.Valor && <div className="text-danger">{errors.Valor}</div>}
        </div>

        <div className="mb-3">
          <label className="form-label">Cidade</label>
          <select name="Cidade" className="form-select" value={formData.Cidade} onChange={handleChange}>
            <option value="">Selecione</option>
            <option value="São Paulo">São Paulo</option>
            <option value="Rio de Janeiro">Rio de Janeiro</option>
            <option value="Belo Horizonte">Belo Horizonte</option>
          </select>
          {errors.Cidade && <div className="text-danger">{errors.Cidade}</div>}
        </div>

        {isProduct && (
          <>
            <div className="mb-3">
              <label className="form-label">Categoria</label>
              <select name="Categoria" className="form-select" value={formData.Categoria} onChange={handleChange}>
                <option value="">Selecione</option>
                <option value="Eletrônicos">Eletrônicos</option>
                <option value="Vestuário">Vestuário</option>
                <option value="Móveis">Móveis</option>
              </select>
              {errors.Categoria && <div className="text-danger">{errors.Categoria}</div>}
            </div>

            <div className="mb-3">
              <label className="form-label">Modelo</label>
              <select name="Modelo" className="form-select" value={formData.Modelo} onChange={handleChange}>
                <option value="">Selecione</option>
                <option value="Smart TV UltraView 4K 55">Smart TV UltraView 4K 55"</option>
                <option value="Jaqueta Puffer Windproof">Jaqueta Puffer Windproof</option>
                <option value="Mesa de Jantar Madeira Prime 6 Lugares">Mesa de Jantar Madeira Prime 6 Lugares</option>
              </select>
              {errors.Modelo && <div className="text-danger">{errors.Modelo}</div>}
            </div>
            
            <div className="mb-3">
              <label className="form-label">Condição</label>
              <select name="Condicao" className="form-select" value={formData.Condicao} onChange={handleChange}>
                <option value="">Selecione</option>
                <option value="Novo">Novo</option>
                <option value="Usado">Usado</option>
                <option value="Seminovo">Seminovo</option>
              </select>
              {errors.Condicao && <div className="text-danger">{errors.Condicao}</div>}
            </div>

            <div className="mb-3">
                <label className="form-label">Quantidade</label>
                <input
                type="number"
                name="Quantidade"
                className="form-control"
                value={formData.Quantidade}
                onChange={handleChange}
                min="1"
                />
                {errors.Quantidade && <div className="text-danger">{errors.Quantidade}</div>}
            </div>
          </>
        )}

        <button type="submit" className="btn btn-success me-2">Confirmar</button>
        <button type="button" className="btn btn-secondary" onClick={Limprar}>Limpar</button>
      </form>
    </div>
  );
};

export default AdForm;

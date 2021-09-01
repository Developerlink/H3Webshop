import React, { useState, useEffect, useCallback } from "react";
import { Col, Row, Button } from "reactstrap";
import ProductForm from "./ProductForm";
import ProductList from "./ProductList";
import styles from "./Products.module.css";

const Products = (props) => {
  const [products, setProducts] = useState([]);
  const [selectedProduct, setSelectedProduct] = useState();
  const [error, setError] = useState(null);

  const fetchProductsHandler = useCallback(async () => {
    setError(null);

    let url = "https://localhost:44331/products";
    let username = "test";
    let password = "test";

    let headers = new Headers();
    headers.append(
      "Authorization",
      "Basic " + window.btoa(username + ":" + password)
    );

    try {
      const response = await fetch(url, { method: "GET", headers: headers });
      const loadedProducts = await response.json();
      setProducts(loadedProducts);
    } catch (error) {
      setError(error.message);
    }
  }, []);

  useEffect(() => {
    fetchProductsHandler();
    console.log("Running my effect!");
  }, [fetchProductsHandler]);

  const newProductHandler = () => {
    setSelectedProduct(null);
    alert("Creating a new product");
  };

  const selectProductHandler = (productId) => {
    //console.log(productId);
    var selectionResult = products.filter((obj) => {
      return obj.id === productId;
    })[0];
    //console.log(selectionResult);
    setSelectedProduct(selectionResult);
    //console.log(selectedProduct.name);
  };

  return (
    <React.Fragment>
      <Row>
        <Col>
          <h1>Product List</h1>
          <ProductList
            products={products}
            onSelectProduct={selectProductHandler}
          />
        </Col>

        <Col>
          <Row>
            <Col>
              <h1>Product</h1>
            </Col>
            <Col>
              <Button
                className={styles.createButton}
                color="primary"
                size="lg"
                onClick={newProductHandler}
              >
                New Product
              </Button>
            </Col>
          </Row>
          <ProductForm product={selectedProduct} />
        </Col>
      </Row>
    </React.Fragment>
  );
};

export default Products;

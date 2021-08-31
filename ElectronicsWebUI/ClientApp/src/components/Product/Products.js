import React, { useState, useEffect, useCallback } from "react";
import { Col, Row } from "reactstrap";
import ProductList from "./ProductList";

const Products = (props) => {
  const [products, setProducts] = useState([]);
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

  return (
    <React.Fragment>
      <Row>
        <Col>
          <h1>Product List</h1>
          <ProductList products={products}/>
        </Col>
        <Col>
          <h1>Product</h1>
        </Col>
      </Row>
    </React.Fragment>
  );
};

export default Products;

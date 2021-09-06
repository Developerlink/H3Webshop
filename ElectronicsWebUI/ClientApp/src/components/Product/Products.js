import React, { useState, useEffect, useCallback } from "react";
import { Col, Row, Button } from "reactstrap";
import ProductList from "./ProductList";
import styles from "./Products.module.css";
import { Dialog } from "@reach/dialog";
import "@reach/dialog/styles.css";
import AddProduct from "./AddProduct";
import EditProduct from "./EditProduct";

const Products = (props) => {
  const [products, setProducts] = useState([]);
  const [productTypes, setProductTypes] = useState([]);
  const [selectedProduct, setSelectedProduct] = useState();
  const [error, setError] = useState(null);
  const [showDialog, setShowDialog] = React.useState(false);

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

  const fetchProductTypesHandler = useCallback(async () => {
    setError(null);
    let url = "https://localhost:44331/producttypes";
    let username = "test";
    let password = "test";

    let headers = new Headers();
    headers.append(
      "Authorization",
      "Basic " + window.btoa(username + ":" + password)
    );

    try {
      const response = await fetch(url, { method: "GET", headers: headers });
      const loadedProductTypes = await response.json();
      // console.log(loadedProductTypes);
      setProductTypes(loadedProductTypes);
    } catch (error) {
      setError(error.message);
    }
  }, []);

  const addProductHandler = async (product) => {
    let productIsValid = true;
    console.log(product);

    if (product.price === "") {
      alert("The price is not set correctly");
      productIsValid = false;
    } else if (product.price < 0 || 100000 < product.price) {
      productIsValid = false;
      alert("The price is not set correctly");
    }
    if (product.description === "") {
      if (product.description.length > 2500) {
        productIsValid = false;
        alert("The description is too long");
      }
    }
    if (product.name === "") {
      alert("The name is missing");
      productIsValid = false;
    } else if (100 < product.name.length) {
      productIsValid = false;
      alert("The name is too long");
    }

    if (productIsValid) {
      //console.log(product);
      let url = "https://localhost:44331/products";
      let username = "test";
      let password = "test";

      try {
        const response = await fetch(url, {
          method: "POST",
          body: JSON.stringify(product),
          headers: {
            Accept: "application/json",
            "Content-Type": "application/json",
            Authorization: "Basic " + window.btoa(username + ":" + password),
          },
        });
        const data = await response.json();
        console.log(data);
      } catch (error) {}

      setShowDialog(false);
      fetchProductsHandler();
    } else {
      console.log("")
    }
  };

  const updateProductHandler = async (product) => {
    //console.log(product);
    let url = "https://localhost:44331/products/" + product.id;
    let username = "test";
    let password = "test";

    try {
      const response = await fetch(url, {
        method: "PUT",
        body: JSON.stringify(product),
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
          Authorization: "Basic " + window.btoa(username + ":" + password),
        },
      });
      const data = await response.json();
      //console.log(data);
    } catch (error) {}

    setShowDialog(false);
    fetchProductsHandler();
  };

  const deleteProductHandler = async (id) => {
    console.log(id);
    let url = "https://localhost:44331/products/" + id;
    let username = "test";
    let password = "test";

    try {
      const response = await fetch(url, {
        method: "DELETE",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
          Authorization: "Basic " + window.btoa(username + ":" + password),
        },
      });
      const data = await response.json();
      console.log(data);
    } catch (error) {}

    setShowDialog(false);
    fetchProductsHandler();
  };

  useEffect(() => {
    fetchProductsHandler();
    fetchProductTypesHandler();
    console.log("Running my effect!");
  }, [fetchProductsHandler, fetchProductTypesHandler]);

  const newProductHandler = () => {
    setSelectedProduct(null);
    setShowDialog(true);
  };

  const closeDialogHandler = () => setShowDialog(false);

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
      <div>
        <Dialog
          className={styles.dialog}
          aria-labelledby="newProductDialog"
          aria-describedby="A popup form to submit a new product"
          isOpen={showDialog}
          onDismiss={closeDialogHandler}
        >
          <AddProduct
            onSubmit={addProductHandler}
            productTypes={productTypes}
          />
        </Dialog>
      </div>
      <Row>
        <Col>
          <Row>
            <Col>
              <h1>Product List</h1>
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
          <ProductList
            products={products}
            onSelectProduct={selectProductHandler}
          />
        </Col>

        <Col>
          <h1>Product</h1>
          <EditProduct
            product={selectedProduct}
            productTypes={productTypes}
            onUpdate={updateProductHandler}
            onDelete={deleteProductHandler}
          />
        </Col>
      </Row>
    </React.Fragment>
  );
};

export default Products;

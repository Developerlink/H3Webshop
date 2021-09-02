import React, { useState, useEffect, useCallback } from "react";
import { Col, Row, Button } from "reactstrap";
import ProductForm from "./ProductForm";
import ProductList from "./ProductList";
import styles from "./Products.module.css";
import { Dialog} from "@reach/dialog";
import "@reach/dialog/styles.css";
import NewProductForm from "./NewProductForm";

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

  const saveHandler = () => {
    setShowDialog(false);
  };

  return (
    <React.Fragment>
      <div>
        <Dialog isOpen={showDialog} onDismiss={closeDialogHandler}>
          <NewProductForm onSubmit={saveHandler} productTypes={productTypes} />
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
          <ProductForm product={selectedProduct} productTypes={productTypes} />
        </Col>
      </Row>
    </React.Fragment>
  );
};

export default Products;

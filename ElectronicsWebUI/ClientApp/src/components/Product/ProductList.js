import React from "react";
import { ListGroup, ListGroupItem } from "reactstrap";
import styles from "./ProductList.module.css";

const ProductList = (props) => {
  //console.log("inside productlist props");
  //console.log(props.products);

  const onSelectHandler = (event) => {
    props.onSelectProduct(parseInt(event.target.id));
  };

  return (
    <ListGroup className={styles["list-group"]}>
      {props.products.map((product) => (
        <ListGroupItem
          id={product.id}
          onClick={onSelectHandler}
          key={product.id}
          value={product.id}
          tag="button"
          action
        >
          <h6 id={product.id}>{product.name}</h6>
          <p id={product.id}>{product.price} kr</p>
          <p id={product.id}>{product.productType.name}</p>
        </ListGroupItem>
      ))}
    </ListGroup>
  );
};

export default ProductList;

import React, { useEffect, useState } from "react";
import { Button, Form, FormGroup, Label, Input } from "reactstrap";
import styles from "./ProductForm.module.css";

const emptyProduct = {
  id: "",
  name: "",
  description: "",
  price: "",
  productType: {
    id: "",
    name: "",
  },
};

const ProductForm = (props) => {
  const [product, setProduct] = useState(emptyProduct);
  const [selectedOption, setSelectedOption] = useState(0);

  useEffect(() => {
    if (props.product) {
      console.log("props.product is set");
      console.log(props.product.id);
      setProduct(props.product);
      setSelectedOption(props.product.productType.id)
    } else {
      console.log("props.product is NOT set!");
    }
  }, [props.product]);

  const onChangeHandler = (event) => {
    const { name, value } = event.target;

    console.log(value);

    setProduct((prevValue) => {
      return {
        ...prevValue,
        [name]: value,
      };
    });

    console.log(product);
  };

  const selectOptionHandler = (event) => {
    const { name: productType, value: id } = event.target;
    console.log(productType + " " + id);
    setProduct((prevValue) => {
      return {
        ...prevValue,
        [productType]: { id: id, name: ''},
      };
    });
    setSelectedOption(id);
    console.log(product);
  };

  const updateHandler = () => {
    props.onUpdate(product);
  };

  const deleteHandler = () => {
    props.onDelete(product.id);
    setProduct(emptyProduct);
    setSelectedOption(0);
  }; 

  return (
    <React.Fragment>
      <Form>
        <FormGroup>
          <Label>Name</Label>
          <Input
            type="text"
            name="name"
            id="name"
            placeholder="product name"
            value={product.name}
            onChange={onChangeHandler}
          />
        </FormGroup>
        <FormGroup>
          <Label>Select Product Type</Label>
          <Input
            type="select"
            name="productType"
            value={selectedOption}
            onChange={selectOptionHandler}
          >
            {props.productTypes.map((productType) => (
              <option
                onClick={selectOptionHandler}
                key={productType.id}
                value={productType.id}
              >
                {productType.name}
              </option>
            ))}
          </Input>
        </FormGroup>
        <FormGroup>
          <Label>Decription</Label>
          <Input
            className={styles.listGroup}
            type="textarea"
            name="description"
            id="description"
            value={product.description}
            onChange={onChangeHandler}
          />
        </FormGroup>
        <FormGroup>
          <Label>Price</Label>
          <Input
            type="number"
            name="price"
            id="price"
            placeholder="amount"
            step="1"
            min={0}
            max={100000}
            value={product.price}
            onChange={onChangeHandler}
          />
        </FormGroup>
        <FormGroup>
          <Label type="hidden" name="id" value={product.id} />
        </FormGroup>

        <div>
          <Button onClick={updateHandler} color="info">
            Update
          </Button>{" "}
          <Button onClick={deleteHandler} color="danger">
            Delete
          </Button>{" "}
        </div>
      </Form>
    </React.Fragment>
  );
};

export default ProductForm;

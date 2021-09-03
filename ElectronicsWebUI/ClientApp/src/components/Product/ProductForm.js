import React, { useEffect, useState } from "react";
import {
  Button,
  Form,
  FormGroup,
  Label,
  Input,
  FormFeedback,
} from "reactstrap";
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
  const [nameIsInvalid, setNameIsInvalid] = useState(false);
  const [selectedOption, setSelectedOption] = useState(0);
  const [descriptionIsInvalid, setdescripTionIsInvalid] = useState(false);
  const [priceIsInvalid, setPriceIsInvalid] = useState(false);

  useEffect(() => {
    if (props.product) {
      console.log("props.product is set");
      console.log(props.product.id);
      setProduct(props.product);
      setSelectedOption(props.product.productType.id);
    } else {
      console.log("props.product is NOT set!");
    }
  }, [props.product]);

  const onChangeHandler = (event) => {
    const { name, value } = event.target;

    console.log(value);

    if (name === "price") {
      if (value < 0 || 100000 < value) {
        setPriceIsInvalid(true);
      } else {
        setPriceIsInvalid(false);
      }
    }
    if (name === "name") {
      if (value.length < 1 || 100 < value.length) {
        setNameIsInvalid(true);
      } else {
        setNameIsInvalid(false);
      }
    }
    if (name === "description") {
      if (value.length < 0 || 2500 < value.length) {
        setdescripTionIsInvalid(true);
      } else {
        setdescripTionIsInvalid(false);
      }
    }

    setProduct((prevValue) => {
      return {
        ...prevValue,
        [name]: value,
      };
    });

    //console.log(product);
  };

  const selectOptionHandler = (event) => {
    const { name: productType, value: id } = event.target;
    console.log(productType + " " + id);
    setProduct((prevValue) => {
      return {
        ...prevValue,
        [productType]: { id: id, name: "" },
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
            invalid={nameIsInvalid}
          />
          <FormFeedback>The name cannot be empty or more than 100 characters</FormFeedback>
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
            invalid={descriptionIsInvalid}
          />
          <FormFeedback>The description cannot be more than 2500 characters</FormFeedback>
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
            invalid={priceIsInvalid}
          />
          <FormFeedback>The price amount must be valid (0-100.000)</FormFeedback>
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

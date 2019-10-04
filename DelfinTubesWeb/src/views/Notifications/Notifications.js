/*eslint-disable*/
import React from "react";
// nodejs library to set properties for components
import PropTypes from "prop-types";
// @material-ui/core components
import { makeStyles } from "@material-ui/core/styles";
// @material-ui/icons
import AddAlert from "@material-ui/icons/AddAlert";
// core components
import GridItem from "components/Grid/GridItem.js";
import GridContainer from "components/Grid/GridContainer.js";
import Card from "components/Card/Card.js";
import Table from "components/Table/Table.js";
import TableBody from "@material-ui/core/TableBody";
import TableCell from "@material-ui/core/TableCell";
import TableHead from "@material-ui/core/TableHead";
import TableRow from "@material-ui/core/TableRow";
import CardHeader from "components/Card/CardHeader.js";
import CardBody from "components/Card/CardBody.js";
import CustomInput from "components/CustomInput/CustomInput.js";

const styles = {
  cardCategoryWhite: {
    "&,& a,& a:hover,& a:focus": {
      color: "rgba(255,255,255,.62)",
      margin: "0",
      fontSize: "14px",
      marginTop: "0",
      marginBottom: "0"
    },
    "& a,& a:hover,& a:focus": {
      color: "#FFFFFF"
    }
  },
  cardTitleWhite: {
    color: "#FFFFFF",
    marginTop: "0px",
    minHeight: "auto",
    fontWeight: "300",
    fontFamily: "'Roboto', 'Helvetica', 'Arial', sans-serif",
    marginBottom: "3px",
    textDecoration: "none",
    "& small": {
      color: "#777",
      fontSize: "65%",
      fontWeight: "400",
      lineHeight: "1"
    }
  }
};

const useStyles = makeStyles(styles);

export default function Icons() {
  const classes = useStyles();
  return (
    <GridContainer>
      <GridItem xs={12} sm={6} md={6} >
        <Card>
          <CardHeader plain color="primary">
            <h4 className={classes.cardTitleWhite}>Gestión de anuncios</h4>
          </CardHeader>
          <CardBody>
            <GridItem xs={12}>
              <Table
                tableHeaderColor="primary"
                tableHead={["Anuncio", ""]}
                tableData={[
                  ["15/09/2019 15:10 - Reconocimiento médico", <i className="material-icons" style={{ cursor: "pointer" }}>create</i>, <i className="material-icons" style={{ cursor: "pointer", color: "red" }}>delete_forever</i>],
                  ["17/09/2019 16:08 - Nueva normativa de entrada", <i className="material-icons" style={{ cursor: "pointer" }}>create</i>, <i className="material-icons" style={{ cursor: "pointer", color: "red" }}>delete_forever</i>],
                  ["21/09/2019 17:00 - Compra de cascos nuevos", <i className="material-icons" style={{ cursor: "pointer" }}>create</i>, <i className="material-icons" style={{ cursor: "pointer", color: "red" }}>delete_forever</i>],
                ]}
              />
            </GridItem>
          </CardBody>
        </Card>
      </GridItem>

      <GridItem xs={12} sm={6} md={6} >
        <Card>
          <CardHeader plain color="primary">
            <h4 className={classes.cardTitleWhite}>Grupos a los que pertenece</h4>
          </CardHeader>
          <CardBody>
            <GridItem xs={12}>
              <Table
                tableHeaderColor="primary"
                tableData={[
                  [<i className="material-icons" style={{ fontSize: '30px' }}>crop_square</i>, "Adminstración", <i className="material-icons" style={{ cursor: "pointer" }}>remove_red_eye</i>],
                  [<i className="material-icons" style={{ fontSize: '30px' }}>crop_square</i>, "Guardias de seguridad", <i className="material-icons" style={{ cursor: "pointer" }}>remove_red_eye</i>],
                  [<i className="material-icons" style={{ fontSize: '30px' }}>crop_square</i>, "Operarios", <i className="material-icons" style={{ cursor: "pointer" }}>remove_red_eye</i>],
                  [<i className="material-icons" style={{ fontSize: '30px' }}>crop_square</i>, "Maestros", <i className="material-icons" style={{ cursor: "pointer" }}>remove_red_eye</i>],
                  [<i className="material-icons" style={{ fontSize: '30px' }}>crop_square</i>, "Carretilleros", <i className="material-icons" style={{ cursor: "pointer" }}>remove_red_eye</i>]
                ]}
              />
            </GridItem>
          </CardBody>
        </Card>
      </GridItem>

      <Card>
        <CardHeader plain color="primary">
          <h4 className={classes.cardTitleWhite}>Datos del anuncio</h4>
        </CardHeader>
        <GridItem >
          <CardBody>
            <GridItem xs={12}>
              <CustomInput
                labelText="Asunto"
                id="company-disabled"
                formControlProps={{
                  fullWidth: true
                }}
                inputProps={{
                  disabled: false
                }}
              />
            </GridItem>
            <GridItem xs={12}>
              <CustomInput
                labelText="Descripción"
                id="0"
                formControlProps={{
                  fullWidth: true
                }}
                inputProps={{
                  disabled: false
                }}
              />
            </GridItem>
            <GridItem xs={6} md={6} sm={6} style={{ marginTop: "25px" }}>
              <i className={"material-icons"} style={{ fontSize: "40px" }}>cloud_upload</i>
              <label style={{ color: 'black' }}>&nbsp;Adjuntar documento</label>
            </GridItem>
            <GridItem xs={6} md={6} sm={6} style={{ marginTop: "25px" }}>
              <i className={"material-icons"} style={{ fontSize: "40px" }}>delete_outline</i>
              <label style={{ color: 'black' }}>&nbsp;Eliminar anuncio</label>
            </GridItem>
          </CardBody>
        </GridItem>
      </Card>

      <GridItem xs={12}>
        <div style={{ textAlign: 'right' }}>
          <br />
          <br />
          <br />
          <label style={{ fontSize: '30px', color: 'green' }}>Enviar Anuncio  </label>
          <i className="material-icons" style={{ fontSize: '50px', color: 'green', verticalAlign: 'top' }}>send</i>
        </div>
      </GridItem>
    </GridContainer>


  );
}

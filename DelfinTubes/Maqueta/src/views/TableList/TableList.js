import React from "react";
// @material-ui/core components
import { makeStyles } from "@material-ui/core/styles";
// core components
import GridItem from "components/Grid/GridItem.js";
import GridContainer from "components/Grid/GridContainer.js";
import Table from "components/Table/Table.js";
import Card from "components/Card/Card.js";
import CardHeader from "components/Card/CardHeader.js";
import CardBody from "components/Card/CardBody.js";
import DelfintubesIco from "assets/img/delfintubes_ico.jpg"
import { Grid } from "@material-ui/core";

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
  },
};

const useStyles = makeStyles(styles);

export default function TableList() {
  const classes = useStyles();
  return (
    <GridContainer xs={12}>
        <Card>
          <CardHeader color="primary">
            <h4 className={classes.cardTitleWhite}>Incidencias sin resolver</h4>
            {/* <p className={classes.cardCategoryWhite}>
              Here is a subtitle for this table
            </p> */}
          </CardHeader>
          <CardBody>
            <GridContainer >
              <GridContainer xs={8}>
                <Table
                  tableHeaderColor="primary"
                  tableHead={["Fecha", "Nombre", "Apellidos", "Tipo de solicitud", ""]}
                  tableData={[
                    ["20/09/2018", "Arturo", "González Campos", "Solicitud de vacaciones", <i className="material-icons" style={{ cursor: "pointer" }}>create</i>],
                    ["21/01/2019", "Rodrigo", "Cortés", "Caso caducado", <i className="material-icons" style={{ cursor: "pointer" }}>create</i>],
                    ["21/01/2019", "Juan", "Gómez Jurado", "Justificante médico", <i className="material-icons" style={{ cursor: "pointer" }}>create</i>],
                  ]} />
              </GridContainer>

              <GridContainer style={{paddingLeft:"130px", paddingTop:"30px"}}>
                <GridItem style={{ margin: "auto"}}>
                  <CardBody style={{ margin: "auto" }}>
                    <label style={{ textAlign: "center" }}>
                      <a href="#">Alta/modificación usuario</a> </label>
                  </CardBody>
                  <CardBody style={{ margin: "auto" }}>
                    <label style={{ textAlign: "center" }}>
                      <a href="#">Envío de anuncio </a></label>
                  </CardBody>
                  <CardBody style={{ margin: "auto" }}>
                    <label style={{ textAlign: "center" }}>
                      <a href="#">Gestión de nóminas</a> </label>
                  </CardBody>
                </GridItem>
              </GridContainer>
            </GridContainer>
          </CardBody>
        </Card>
    </GridContainer>
  );
}

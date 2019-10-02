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
  paddingLeft:{
    paddingLeft:"245px"
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
    <GridContainer>
      <GridItem xs={12}>
        <Card>
          <CardHeader color="primary">
            <h4 className={classes.cardTitleWhite}>Incidencias sin resolver</h4>
            {/* <p className={classes.cardCategoryWhite}>
              Here is a subtitle for this table
            </p> */}
          </CardHeader>
          <CardBody>
            <GridContainer xs={12}>
              <GridContainer>
                <Table
                  tableHeaderColor="primary"
                  tableHead={["Fecha", "Nombre", "Apellidos", "Tipo de solicitud", ""]}
                  tableData={[
                    ["20/09/2018", "Arturo", "González Campos", "Solicitud de vacaciones", <i className="material-icons" style={{ cursor: "pointer" }}>create</i>],
                    ["21/01/2019", "Rodrigo", "Cortés", "Caso caducado", <i className="material-icons" style={{ cursor: "pointer" }}>create</i>],
                    ["21/01/2019", "Juan", "Gómez Jurado", "Justificante médico", <i className="material-icons" style={{ cursor: "pointer" }}>create</i>],
                  ]} />
              </GridContainer>

              <GridContainer className={classes.paddingLeft} >
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
            {/* <GridItem xs={4} style={{ margin: "auto" }}>
              <Card>
                <CardBody style={{ margin: "auto" }}>
                  <label style={{ textAlign: "center" }}>
                    <a href="">Alta/modificación usuario</a> </label>
                </CardBody>
                <CardBody style={{ margin: "auto" }}>
                  <label style={{ textAlign: "center" }}>
                    <a href="www.google.es">Envío de anuncio </a></label>
                </CardBody>
                <CardBody style={{ margin: "auto" }}>
                  <label style={{ textAlign: "center" }}>
                    <a href="www.google.es">Gestión de nóminas</a> </label>
                </CardBody>
              </Card>
            </GridItem> */}


          </CardBody>
        </Card>
      </GridItem>



      {/* <GridItem xs={12} sm={12} md={12}>
        <Card plain>
          <CardHeader plain color="primary">
            <h4 className={classes.cardTitleWhite}>
              Table on Plain Background
            </h4>
            <p className={classes.cardCategoryWhite}>
              Here is a subtitle for this table
            </p>
          </CardHeader>
          <CardBody>
            <Table
              tableHeaderColor="primary"
              tableHead={["ID", "Name", "Country", "City", "Salary"]}
              tableData={[
                ["1", "Dakota Rice", "$36,738", "Niger", "Oud-Turnhout"],
                ["2", "Minerva Hooper", "$23,789", "Curaçao", "Sinaai-Waas"],
                ["3", "Sage Rodriguez", "$56,142", "Netherlands", "Baileux"],
                [
                  "4",
                  "Philip Chaney",
                  "$38,735",
                  "Korea, South",
                  "Overland Park"
                ],
                [
                  "5",
                  "Doris Greene",
                  "$63,542",
                  "Malawi",
                  "Feldkirchen in Kärnten"
                ],
                ["6", "Mason Porter", "$78,615", "Chile", "Gloucester"]
              ]}
            />
          </CardBody>
        </Card>
      </GridItem> */}
    </GridContainer>
  );
}

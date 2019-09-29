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
  }
};

const useStyles = makeStyles(styles);

export default function TableList() {
  const classes = useStyles();
  return (
    <GridContainer>
      <GridItem xs={4}>
        <Card>
          <CardHeader color="primary">
            <h4 className={classes.cardTitleWhite}>Usuarios </h4>
            {/* <p className={classes.cardCategoryWhite}>
              Here is a subtitle for this table
            </p> */}
          </CardHeader>
          <CardBody>
            <Table
              tableHeaderColor="primary"
              tableHead={["Usuario", ""]}
              tableData={[
                ["José González", <i className="material-icons" style={{ cursor: "pointer" }}>create</i>],
                ["Arturo Campos", <i className="material-icons" style={{ cursor: "pointer" }}>create</i>],
                ["Rodrigo Cortés", <i className="material-icons" style={{ cursor: "pointer" }}>create</i>],
                ["Juan Gómez Jurado", <i className="material-icons" style={{ cursor: "pointer" }}>create</i>],
                ["Cristina Alonso", <i className="material-icons" style={{ cursor: "pointer" }}>create</i>],
                ["María Josefina de los Campos", <i className="material-icons" style={{ cursor: "pointer" }}>create</i>],
                ["DelfínTubes", <i className="material-icons" style={{ cursor: "pointer" }}>create</i>]
              ]}
            />
          </CardBody>
        </Card>
      </GridItem>

      <GridItem xs={4} style={{ margin: "auto" }}>
        <Card>
          <CardBody style={{ margin: "auto" }}>
            <label style={{ textAlign: "center" }}>
              <a href="www.google.es"> Alta/modificación usuario</a> </label>
          </CardBody>
          <CardBody style={{ margin: "auto" }}>
            <label style={{ textAlign: "center" }}>
              <a href="www.google.es"> Envío de anuncio </a></label>
          </CardBody>
          <CardBody style={{ margin: "auto" }}>
            <label style={{ textAlign: "center" }}>
              <a href="www.google.es"> Gestión de nóminas</a> </label>
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

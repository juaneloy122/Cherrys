import React from "react";
// react plugin for creating charts
import ChartistGraph from "react-chartist";
// @material-ui/core
import { makeStyles } from "@material-ui/core/styles";
import Icon from "@material-ui/core/Icon";
// @material-ui/icons
import Store from "@material-ui/icons/Store";
import Warning from "@material-ui/icons/Warning";
import DateRange from "@material-ui/icons/DateRange";
import LocalOffer from "@material-ui/icons/LocalOffer";
import Update from "@material-ui/icons/Update";
import ArrowUpward from "@material-ui/icons/ArrowUpward";
import AccessTime from "@material-ui/icons/AccessTime";
import Accessibility from "@material-ui/icons/Accessibility";
import BugReport from "@material-ui/icons/BugReport";
import Code from "@material-ui/icons/Code";
import Cloud from "@material-ui/icons/Cloud";
// core components
import GridItem from "components/Grid/GridItem.js";
import GridContainer from "components/Grid/GridContainer.js";
import Table from "components/Table/Table.js";
import Tasks from "components/Tasks/Tasks.js";
import CustomTabs from "components/CustomTabs/CustomTabs.js";
import Danger from "components/Typography/Danger.js";
import Card from "components/Card/Card.js";
import CardHeader from "components/Card/CardHeader.js";
import CardIcon from "components/Card/CardIcon.js";
import CardBody from "components/Card/CardBody.js";
import CardFooter from "components/Card/CardFooter.js";
import CustomInput from "components/CustomInput/CustomInput.js";
import { bugs, website, server } from "variables/general.js";

import {
  dailySalesChart,
  emailsSubscriptionChart,
  completedTasksChart
} from "variables/charts.js";

import styles from "assets/jss/material-dashboard-react/views/dashboardStyle.js";
import { Grid } from "@material-ui/core";

const useStyles = makeStyles(styles);

export default function Dashboard() {
  const classes = useStyles();
  return (
    <div>
      <GridContainer style={{ marginTop: "150px" }}>
        <GridItem xs={12} sm={6} md={6} >
          <Card>
            <CardHeader plain color="primary">
              <h4 className={classes.cardTitleWhite}>Gestión de incidencias  (3)</h4>
            </CardHeader>
            <CardBody>
              <GridItem xs={12}>
                <Table
                  tableHeaderColor="primary"
                  tableHead={["Incidencias", ""]}
                  tableData={[
                    ["15/09/2019 15:10 - Solicitud de vacaciones", <i className="material-icons" style={{ cursor: "pointer" }}>create</i>],
                    ["17/09/2019 16:08 - Casco caducado", <i className="material-icons" style={{ cursor: "pointer" }}>create</i>],
                    ["21/09/2019 17:00 - Justificante médico", <i className="material-icons" style={{ cursor: "pointer" }}>create</i>],
                  ]}
                />
              </GridItem>
            </CardBody>
          </Card>
        </GridItem>

        <GridItem xs={12} sm={6} md={6} >
          <Card>
            <CardHeader plain color="primary">
              <h4 className={classes.cardTitleWhite}>Datos de la incidencia</h4>
            </CardHeader>
            <GridItem >
              <CardBody>
                <GridItem xs={12}>
                  <label style={{ color: '#a13bb6', fontSize: '30px' }}>Solicitud de Vacaciones</label>
                </GridItem>
                <GridItem xs={12}>
                  <p>Solicito el día jueves 11 de Mayo para poder ir a la operación de mi hija María. Me ausentaré todo el día.</p>
                </GridItem>
                <GridItem>
                  <CustomInput
                    labelText="Respuesta"
                    id="company-disabled"
                    formControlProps={{
                      fullWidth: true
                    }}
                    inputProps={{
                      disabled: false
                    }}
                  />
                </GridItem>
              </CardBody>
            </GridItem>
          </Card>
        </GridItem>

        <GridItem xs={12} sm={12} md={12}>
          <div style={{ textAlign: 'right' }}>
            <br />
            <br /><br/>
            <br/>
            <br/><br/>
            <br/>
            <br/><br/>
            <br/>
            <br/><br/>
            <br />
            <label style={{ fontSize: '30px', color: 'green' }}>Resolver Incidencia  </label>
            <i className="material-icons" style={{ fontSize: '50px', color: 'green', verticalAlign: 'top' }}>send</i>
          </div>
        </GridItem>

      </GridContainer>
    </div>
  );
}
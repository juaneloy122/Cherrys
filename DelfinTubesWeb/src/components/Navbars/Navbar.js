import React from "react";
import classNames from "classnames";
import logo from "assets/img/FotoPerfil.png";
import PropTypes from "prop-types";
import GridContainer from "components/Grid/GridContainer.js";
import imagenDelfinTubes from "assets/img/delfintubes.jpg";
// @material-ui/core components
import { makeStyles } from "@material-ui/core/styles";
import AppBar from "@material-ui/core/AppBar";
import ImageComponent from "react-rounded-image";
import Toolbar from "@material-ui/core/Toolbar";
import IconButton from "@material-ui/core/IconButton";
import Hidden from "@material-ui/core/Hidden";
// @material-ui/icons
import Menu from "@material-ui/icons/Menu";
// core components
import AdminNavbarLinks from "./AdminNavbarLinks.js";
import RTLNavbarLinks from "./RTLNavbarLinks.js";
import Button from "components/CustomButtons/Button.js";

import styles from "assets/jss/material-dashboard-react/components/headerStyle.js";
import { Grid } from "@material-ui/core";
import GridItem from "components/Grid/GridItem.js";

const useStyles = makeStyles(styles);

export default function Header(props) {
  const classes = useStyles();
  function makeBrand() {
    var name;
    props.routes.map(prop => {
      if (window.location.href.indexOf(prop.layout + prop.path) !== -1) {
        name = props.rtlActive ? prop.rtlName : prop.name;
      }
      return null;
    });
    return name;
  }
  const { color } = props;
  const appBarClasses = classNames({
    [" " + classes[color]]: color
  });
  return (
    //   <AppBar className={classes.appBar + appBarClasses}>
    //     <Toolbar className={classes.container}>

    //       <Hidden smDown implementation="css">
    //         {props.rtlActive ? <RTLNavbarLinks /> : <AdminNavbarLinks />}
    //       </Hidden>
    //       <Hidden mdUp implementation="css">
    //         <IconButton
    //           color="inherit"
    //           aria-label="open drawer"
    //           onClick={props.handleDrawerToggle}
    //         >
    //           <Menu />
    //         </IconButton>
    //       </Hidden>
    //     </Toolbar>
    //   </AppBar>
    // );
    <AppBar style={{ background: '#FFF' }}>
        <GridContainer>
          <GridItem xs={9}>
            <img src={imagenDelfinTubes} style={{ width: '300px', height: '100px', padding: '0px' }}></img>
          </GridItem>
          <GridItem xs={2} style={{marginTop: '40px'}} >
            <label  style={{ color: '#08283d',fontWeight: 'bold', paddingLeft: '115px',fontSize: '20px', verticalAlign: 'center', marginRigh: '10px', marginTop: '20px!Important'}}>Sandra Lago</label>
          </GridItem>
          <GridItem xs={1} style={{marginTop: '8px'}}>
              <ImageComponent
                image={logo}
                roundedColor="white"
                textAlign="center"
                imageWidth="80"
                imageHeight="80"
                roundedSize="8"
              >
               
              </ImageComponent>
             
          </GridItem>
        </GridContainer>
    </AppBar>
  )
}

Header.propTypes = {
  color: PropTypes.oneOf(["primary", "info", "success", "warning", "danger"]),
  rtlActive: PropTypes.bool,
  handleDrawerToggle: PropTypes.func,
  routes: PropTypes.arrayOf(PropTypes.object)
};

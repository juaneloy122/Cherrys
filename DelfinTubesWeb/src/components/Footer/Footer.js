/*eslint-disable*/
import React from "react";
import PropTypes from "prop-types";
// @material-ui/core components
import { makeStyles } from "@material-ui/core/styles";
import ListItem from "@material-ui/core/ListItem";
import List from "@material-ui/core/List";
// core components
import styles from "assets/jss/material-dashboard-react/components/footerStyle.js";
import { textAlign } from "@material-ui/system";

const useStyles = makeStyles(styles);

export default function Footer(props) {
  const classes = useStyles();
  return (
    <footer className={classes.footer}>
      <div className={classes.container}>
        <div style={{textAlign:"center"}}>
          {<List className={classes.list}>
            <ListItem className={classes.inlineBlock}>
              <a href="#home" className={classes.block}>
                Política de privacidad
              </a>
            </ListItem>
            <ListItem className={classes.inlineBlock}>
              <a href="" className={classes.block}>
                Aviso legal
              </a>
            </ListItem>
            <ListItem className={classes.inlineBlock}>
              <a href="#portfolio" className={classes.block}>
                Cookies
              </a>
            </ListItem>
          </List>
          }
        </div>
      </div>
    </footer>
  );
}

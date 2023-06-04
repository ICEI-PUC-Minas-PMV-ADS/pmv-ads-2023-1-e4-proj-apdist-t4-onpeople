import React from 'react';
import styled from 'styled-components/native';
import { StatusBar, Platform } from 'react-native';
import { colors } from '../colors';

const { primary } = colors;

const StyledView = styled.View`
flex: 1;
padding: 25px;
/* padding-top:${(Platform.OS === 'android' ? StatusBar.currentHeight : 0) + 30} px; */
background-color:${primary};`

const MainContainer = (props) => {
    return <StyledView {...props}>{props.children}</StyledView>;
};

export default MainContainer;
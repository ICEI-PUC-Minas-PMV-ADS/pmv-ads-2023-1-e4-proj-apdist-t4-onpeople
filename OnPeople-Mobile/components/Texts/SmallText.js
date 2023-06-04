import React from 'react';

//styled components
import styled from 'styled-components/native';
import {colors} from '../colors';
const { tertiary } = colors;

const StyledText = styled.Text`
    font-size: 13px;
    color: ${tertiary};
    text-align: left;
`;

const SmallText = (props) => {
    return <StyledText {...props}>{props.children} </StyledText>;
};

export default SmallText;
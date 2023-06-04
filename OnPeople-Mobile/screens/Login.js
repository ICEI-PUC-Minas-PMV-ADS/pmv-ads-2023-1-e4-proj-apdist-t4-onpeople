import React, { useState } from 'react';
import { Formik } from 'formik';
import * as yup from 'yup';
import { ActivityIndicator } from 'react-native';
import { colors } from '../components/colors';
const { primary } = colors;



//custom components
import MainContainer from '../components/Containers/MainContainer';
import KeyboardAvoidingContainer from '../components/Containers/KeyboardAvoidingContainer';
import StyledTextInput from '../components/Inputs/StyledTextInput';
import MsgBox from '../components/Texts/MsgBox';
import RegularButton from '../components/Buttons/RegularButton';
import StyledLogotipo from '../components/Logo/StyledLogotipo';
import api from '../service/Api';
import AsyncStorage from '@react-native-async-storage/async-storage';


const Login = ({ navigation }) => {
  const [message, setMessage] = useState('');
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [tipoConta, setTipoConta] = useState('');

  const [isSuccessMessage, setIsSuccessMessage] = useState(false);

  const moveTo = (screen, payload) => {
    navigation.navigate(screen, { ...payload });
  };

  const handleLogin = async (values, setSubmitting) => {
    try {
      const { email, password, tipoConta } = values;

      const token = await AsyncStorage.getItem('token');
      console.log(token)
      const response = await api.post('Users/Login', {
        email,
        password,
        tipoConta,
        headers: {

          Authorization: `Bearer ${token}`,
        },
      });


      // Armazena o token no AsyncStorage
      await AsyncStorage.setItem('token', token);

      const userData = response.data;

      if (userData != null && tipoConta === 'Funcionario') {
        navigation.navigate('DashboardMetas', 'UserPerfil', { userData });
      } else if (tipoConta === 'OperacionalRH') {
        navigation.navigate('DashboardFuncionario', 'DashboardMetas', 'DashboardCargos', 'DashboardDepartamentos', { userData });
      } else if (tipoConta === 'GestaoRH') {
        navigation.navigate('DashboardFuncionario', 'DashboardMetas', 'DashboardCargos', 'DashboardDepartamentos', 'DashboardEmpresas', { userData });
      } else {
        throw new Error('Tipo de conta inválido');
      }
    } catch (error) {
    }
  };


  const validationSchema = yup.object().shape({
    email: yup.string().required('Usuário é obrigatório'),
    password: yup.string().required('Senha é obrigatória'),
    tipoConta: yup.string().required('Campo obrigatório'),
  });

  return (
    <MainContainer>
      <KeyboardAvoidingContainer>
        <StyledLogotipo />

        <Formik
          initialValues={{ email: '', password: '', tipoConta: '' }}
          validationSchema={validationSchema}
          onSubmit={(values, { setSubmitting }) => {
            if (values.email == '' || values.email == '' || values.password == '') {
              setMessage('Por favor, preencha todos os campos!');
              setSubmitting(false);
            } else {
              handleLogin(values, setSubmitting);
            }
          }}
        >
          {({ handleChange, handleBlur, handleSubmit, values, isSubmitting }) => (
            <>
              <StyledTextInput
                icon="account-key"
                field={{ name: 'tipoConta', value: values.tipoConta, onChange: handleChange, onBlur: handleBlur }}
                placeholder="Tipo de Conta"
                onChangeText={handleChange('tipoConta')}
              />
              <StyledTextInput
                icon="email-variant"
                placeholder="usuario@gmail.com"
                keyboardType="email-address"
                onChangeText={handleChange('email')}
                onBlur={handleBlur('email')}
                value={values.email}
                style={{ marginBottom: 15 }}
              />

              <StyledTextInput
                icon="lock-open"
                placeholder="* * * * * * * *"
                onChangeText={handleChange('password')}
                onBlur={handleBlur('password')}
                value={values.password}
                isPassword={true}
                style={{ marginBottom: 10 }}
              />
              <MsgBox style={{ marginBottom: 25 }} success={isSuccessMessage}>
                {message || ' '}
              </MsgBox>
              {!isSubmitting && (
                <RegularButton onPress={handleSubmit} title="Login">Entrar</RegularButton>
              )}
              {isSubmitting && (
                <RegularButton disabled={true}>
                  <ActivityIndicator size="small" color={primary} />
                </RegularButton>
              )}
            </>
          )}
        </Formik>
      </KeyboardAvoidingContainer>
    </MainContainer>
  );
};

export default Login;


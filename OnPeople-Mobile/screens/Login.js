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
import LoginService from '../service/LoginService';


const Login = ({ navigation, onLogin }) => {
  const [message, setMessage] = useState('');
  const [userName, setUserName] = useState('');
  const [password, setPassword] = useState('');
  let [userId, setUserId] = useState(0);

  const [isSuccessMessage, setIsSuccessMessage] = useState(false);


  const moveTo = (screen, payload) => {
    navigation.navigate(screen, { ...payload });
  };

  const handleLogin = async (values, setSubmitting) => {
    try {
      const { userName, password } = values;

      const response = await LoginService.login(userName, password);

      userId = response?.data?.id;
      setUserId(userId);

      console.log(`O userid no Login é ${userId}`);

      if (response.status === 200) {
        navigation.navigate('DashboardMetas', { userId });
      }

    }
    catch (error) {

      if (response.status !== 200) {
        throw new Error('Login não efetuado, contacte o administrador dos sistema!');
      }

      console.error('Erro ao efetuar login:', error.message);
    } finally {
      setSubmitting(false);
    }
  }

  const validationSchema = yup.object().shape({
    userName: yup.string().required('Usuário é obrigatório'),
    password: yup.string().required('Senha é obrigatória'),

  });

  return (
    <MainContainer>
      <KeyboardAvoidingContainer>
        <StyledLogotipo />

        <Formik
          initialValues={{ userName: '', password: '' }}
          validationSchema={validationSchema}
          onSubmit={(values, { setSubmitting }) => {
            if (values.userName == '' || values.userName == '' || values.password == '') {
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
                icon="email-variant"
                placeholder="Digite seu usuário"
                keyboardType="email-address"
                onChangeText={handleChange('userName')}
                onBlur={handleBlur('userName')}
                value={values.userName}
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


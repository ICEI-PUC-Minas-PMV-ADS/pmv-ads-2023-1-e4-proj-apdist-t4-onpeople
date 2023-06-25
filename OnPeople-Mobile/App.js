import React, { useState } from 'react';
import { NavigationContainer } from '@react-navigation/native';
import { createStackNavigator } from '@react-navigation/stack';
import Login from './screens/Login';
import DashboardEmpresa from './screens/DashboardEmpresa';
import DashboardCargos from './screens/DashboardCargos';
import DashboardMetas from './screens/DashboardMetas';
import DashboardDepartamentos from './screens/DashboardDepartamentos';
import UserProfile from './screens/UserProfile';

const Stack = createStackNavigator();

const App = () => {

  const [userId, setUserId] = useState(null);

  const onLogin = (id) => {
    setUserId(id);
  };

  const onLogout = () => {
    setUserId(null);
  };

  return (
    <NavigationContainer>
      <Stack.Navigator
        initialRouteName="Login"
      >
        <Stack.Screen name="Login" component={Login}
          options={{ headerShown: false }}
          initialParams={{ onLogin: onLogin }} />
        <Stack.Screen name="DashboardEmpresa" component={DashboardEmpresa}
          options={{ headerShown: false }}
          initialParams={{ onLogin: onLogin }} />
        <Stack.Screen name="DashboardCargos" component={DashboardCargos}
          options={{ headerShown: false }}
          initialParams={{ onLogin: onLogin }} />
        <Stack.Screen name="DashboardMetas" component={DashboardMetas}
          options={{ headerShown: false }}
          initialParams={{ onLogin: onLogin }} />
        <Stack.Screen name="DashboardDepartamentos" component={DashboardDepartamentos}
          options={{ headerShown: false }}
          initialParams={{ onLogin: onLogin }} />
        <Stack.Screen name="UserProfile" component={UserProfile}
          options={{ headerShown: false }}
          initialParams={{ onLogin: onLogin }} />
      </Stack.Navigator>
    </NavigationContainer>

  );
}

export default App;

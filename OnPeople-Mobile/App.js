import React from 'react';
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
  return (
    <NavigationContainer>
      <Stack.Navigator
        initialRouteName="Login"
      >
        <Stack.Screen name="Login" component={Login}
          options={{ headerShown: false }}
        />
        <Stack.Screen name="DashboardEmpresa" component={DashboardEmpresa}
          options={{ headerShown: false }}
        />
        <Stack.Screen name="DashboardCargos" component={DashboardCargos}
          options={{ headerShown: false }}
        />
        <Stack.Screen name="DashboardMetas" component={DashboardMetas}
          options={{ headerShown: false }}
        />
        <Stack.Screen name="DashboardDepartamentos" component={DashboardDepartamentos}
          options={{ headerShown: false }}
        />
        <Stack.Screen name="UserProfile" component={UserProfile}
          options={{ headerShown: false }}
        />
      </Stack.Navigator>
    </NavigationContainer>
  );
};

export default App;

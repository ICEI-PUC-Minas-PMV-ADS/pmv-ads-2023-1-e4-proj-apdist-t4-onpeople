import React, { useState } from 'react';
import { View, Text, StyleSheet, Image, TouchableOpacity, Switch } from 'react-native';
import Icon from 'react-native-vector-icons/FontAwesome';
import { useNavigation } from '@react-navigation/native';
import DashboardEmpresa from './DashboardEmpresa';

Icon.loadFont();

const UserProfile = () => {
  const navigation = useNavigation();

  const userPhoto = require('../assets/user.jpg');

  const [isDarkMode, setIsDarkMode] = useState(false);

  const toggleDarkMode = () => {
    setIsDarkMode(!isDarkMode);
  };

  const handleLogout = () => {
    navigation.navigate('Login');
  };

  const handleGoBack = () => {
    navigation.navigate('DashboardEmpresa');
  };

  return (
    <View style={[styles.container, isDarkMode && styles.darkModeContainer]}>
      <TouchableOpacity style={styles.backButton} onPress={handleGoBack}>
        <Icon name="chevron-left" size={25} color={isDarkMode ? '#FFFFFF' : '#5A5A5A'} />
      </TouchableOpacity>

      <View style={styles.userContainer}>
        <View style={styles.userPhotoContainer}>
          <Image source={userPhoto} style={styles.userPhoto} />
        </View>
        <Text style={[styles.userName, isDarkMode && styles.darkModeText]}>Arnel Pineda</Text>
      </View>

      <View style={styles.field}>
        <Text style={styles.label}>Cargo:</Text>
        <Text style={[styles.value, isDarkMode && styles.darkModeText]}>Desenvolvedor de Software</Text>
      </View>
      <View style={styles.field}>
        <Text style={styles.label}>Departamento:</Text>
        <Text style={[styles.value, isDarkMode && styles.darkModeText]}>TI</Text>
      </View>
      <View style={styles.field}>
        <Text style={styles.label}>Empresa:</Text>
        <Text style={[styles.value, isDarkMode && styles.darkModeText]}>OnPeople</Text>
      </View>
      <View style={styles.field}>
        <Text style={styles.label}>Data de admissão:</Text>
        <Text style={[styles.value, isDarkMode && styles.darkModeText]}>01/01/2023</Text>
      </View>

      <View style={styles.buttonContainer}>
        <View style={styles.switchContainer}>
          <Icon name={isDarkMode ? 'moon-o' : 'sun-o'} size={25} color={isDarkMode ? '#FFFFFF' : '#5A5A5A'} style={{ marginRight: 5 }} />
          <Switch value={isDarkMode} onValueChange={toggleDarkMode} />
        </View>
        <TouchableOpacity
          style={[
            styles.logoutButton,
            isDarkMode ? styles.logoutButtonDark : styles.logoutButtonLight,
          ]}
          onPress={handleLogout}
        >
          <Icon
            name="sign-out"
            size={25}
            color={isDarkMode ? '#FFFFFF' : '#5A5A5A'}
            style={styles.buttonIcon}
          />
          <Text
            style={[
              styles.logoutButtonText,
              isDarkMode ? styles.logoutButtonTextDark : styles.logoutButtonTextLight,
            ]}
          >
            Logout
          </Text>
        </TouchableOpacity>
      </View>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    padding: 50,
    backgroundColor: '#F9F9F9',
    justifyContent: 'center',
  },
  darkModeContainer: {
    backgroundColor: '#1E1E1E',
  },
  backButton: {
    position: 'absolute',
    top: 50,
    left: 40,
    zIndex: 1,
  },
  userContainer: {
    alignItems: 'center',
    marginBottom: 20,
  },
  userPhotoContainer: {
    marginBottom: 10,
  },
  userPhoto: {
    width: 120,
    height: 120,
    borderRadius: 60,
  },
  userName: {
    fontSize: 24,
    color: '#000000',
    fontWeight: 'bold',
    marginBottom: 10,
  },
  darkModeText: {
    color: '#FFFFFF',
  },
  field: {
    marginBottom: 15,
  },
  label: {
    fontWeight: 'bold',
    fontSize: 18,
    marginBottom: 5,
    color: '#5A5A5A',
  },
  value: {
    fontSize: 16,
    color: '#000000',
  },
  buttonContainer: {
    flexDirection: 'row',
    alignItems: 'center',
    justifyContent: 'space-between',
    marginTop: 30,
  },
  switchContainer: {
    flexDirection: 'row',
    alignItems: 'center',
  },
  logoutButton: {
    flexDirection: 'row',
    alignItems: 'center',
    paddingVertical: 10,
    paddingHorizontal: 18,
    borderRadius: 10,
    marginLeft: 10,
    shadowColor: '#000',
    shadowOffset: { width: 0, height: 2 },
    shadowOpacity: 0.2,
    shadowRadius: 2,
    elevation: 2,
  },
  buttonIcon: {
    marginRight: 5,
  },
  logoutButtonText: {
    fontSize: 18,
    color: '#5A5A5A',
  },
  logoutButtonTextDark: {
    color: '#FFFFFF',
  },
});

export default UserProfile;

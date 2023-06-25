import React, { useEffect, useState } from 'react';
import { View, Text, StyleSheet, Image, TouchableOpacity, Switch } from 'react-native';
import Icon from 'react-native-vector-icons/FontAwesome';
import { useNavigation, useRoute } from '@react-navigation/native';
import { getUserProfile } from '../service/UserService';

Icon.loadFont();

const UserProfile = () => {

  const route = useRoute();
  const { userId } = route.params;
  const [user, setUser] = useState(null);
  const [isDarkMode, setIsDarkMode] = useState(false);
  const navigation = useNavigation();

  const userPhoto = require('../assets/usr-placeholder.png');

  useEffect(() => {

    const fetchUserProfile = async () => {
      try {
        const userProfile = await getUserProfile(userId);
        setUser(userProfile);

      } catch (error) {
        console.error('Erro ao obter o perfil do usuário:', error);
      }
    };

    fetchUserProfile();
  }, [userId]);


  const toggleDarkMode = () => {
    setIsDarkMode(!isDarkMode);
  };

  const handleLogout = () => {
    navigation.navigate('Login', { userId });
  };

  const handleGoBack = () => {
    navigation.navigate('DashboardEmpresa', { userId });
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
        <Text style={[styles.userName, isDarkMode && styles.darkModeText]}>{user?.nomeCompleto}</Text>
      </View>

      <View style={styles.field}>
        <Text style={styles.label}>Cargo:</Text>
        <Text style={[styles.value, isDarkMode && styles.darkModeText]}>{user?.nomeCargo}</Text>
      </View>
      <View style={styles.field}>
        <Text style={styles.label}>Departamento:</Text>
        <Text style={[styles.value, isDarkMode && styles.darkModeText]}>{user?.nomeDepartamento}</Text>
      </View>
      <View style={styles.field}>
        <Text style={styles.label}>Empresa:</Text>
        <Text style={[styles.value, isDarkMode && styles.darkModeText]}>{user?.razaoSocial}</Text>
      </View>
      <View style={styles.field}>
        <Text style={styles.label}>Data de admissão:</Text>
        <Text style={[styles.value, isDarkMode && styles.darkModeText]}>{user?.dataAdmissao}</Text>
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

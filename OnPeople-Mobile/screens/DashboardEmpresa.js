import React, { useState, useEffect, Alert } from 'react';
import { View, Text, StyleSheet, Image, TouchableOpacity, Switch } from 'react-native';
import Icon from 'react-native-vector-icons/FontAwesome';
import { useNavigation } from '@react-navigation/native';
import Dropdown from '../components/Dropdown/Dropdown';
import { getEmpresas, getNumeroEmpresasAtivas, getFiliais } from '../service/EmpresasService';


Icon.loadFont();

const DashboardEmpresa = () => {
  const [empresas, setEmpresas] = useState([]);
  const [numeroEmpresasAtivas, setNumeroEmpresasAtivas] = useState(0);
  const [filiais, setFiliais] = useState([]);
  const [filiaisAtivas, setFiliaisAtivas] = useState([]);
  const [countFiliais, setCountFiliais] = useState(0);

  const useFetchData = (fetchFunction, setterFunction) => {
    useEffect(() => {
      const fetchData = async () => {
        try {
          const data = await fetchFunction();
          setterFunction(data);
        } catch (error) {
          console.error('Erro ao obter os dados:', error);
        }
      };

      fetchData();
    }, []);
  };

  // Filiais ativas
  useEffect(() => {
    const filiaisAtivas = filiais.filter((filial) => filial.ativa);
    console.info(filiais)
    setFiliaisAtivas(filiaisAtivas);
  }, [filiais]);


  // Todas as empresas
  useFetchData(getEmpresas, setEmpresas);

  // Verifica empresas ativas
  useFetchData(getNumeroEmpresasAtivas, setNumeroEmpresasAtivas);

  // Todas as filiais
  useFetchData(getFiliais, setFiliais);

  const navigation = useNavigation();

  const userPhoto = require('../assets/usr-placeholder.png');

  const [isDarkMode, setIsDarkMode] = useState(false);

  const [selectedOption, setSelectedOption] = useState('');

  const handleOptionSelect = (option) => {
    setSelectedOption(option);
    navigateToScreen(option);
  };

  const randomColor = () => {
    const letters = '0123456789ABCDEF';
    let color = '#';
    for (let i = 0; i < 6; i++) {
      color += letters[Math.floor(Math.random() * 16)];
    }
    return color;
  };

  const randomColorDark = () => {
    const letters = '0123456789ABCDEF';
    let color = '#';
    for (let i = 0; i < 3; i++) {
      color += letters[Math.floor(Math.random() * 10)];
    }
    return color;
  };

  const block1Color = isDarkMode ? randomColor() : randomColorDark();
  const block2Color = isDarkMode ? randomColor() : randomColorDark();
  const block3Color = isDarkMode ? randomColor() : randomColorDark();
  const block4Color = isDarkMode ? randomColor() : randomColorDark();

  const toggleDarkMode = () => {
    setIsDarkMode(!isDarkMode);
  };

  const handleLogout = () => {
    navigation.navigate('Login');
  };

  const handleProfilePress = () => {
    navigation.navigate('UserProfile');
  };

  const navigateToScreen = (option) => {
    switch (option) {
      case 'Empresas':
        navigation.navigate('DashboardEmpresa');
        break;
      case 'Metas':
        navigation.navigate('DashboardMetas');
        break;
      case 'Departamentos':
        navigation.navigate('DashboardDepartamentos');
        break;
      case 'Cargos':
        navigation.navigate('DashboardCargos');
        break;
      default:
        break;
    }
  };

  return (
    <View style={[styles.container, isDarkMode && styles.darkModeContainer]}>
      <TouchableOpacity style={styles.userContainer} onPress={handleProfilePress}>
        <View style={styles.userPhotoContainer}>
          <Image source={userPhoto} style={styles.userPhoto} />
        </View>
        <View>
          <Text style={[styles.userName, isDarkMode && styles.darkModeText]}>Arnel Pineda</Text>
        </View>
      </TouchableOpacity>

      <Dropdown
        options={['Metas', 'Departamentos', 'Cargos']}
        selectedOption={selectedOption}
        onSelect={handleOptionSelect}
      />

      <View style={[styles.block, { borderLeftColor: block1Color, shadowColor: block1Color }]}>
        <View style={styles.blockContent}>
          <Icon name="building" size={30} color={block1Color} style={styles.icon} />
          <View style={styles.blockText}>
            <Text style={[styles.heading, { color: block1Color }]}>Total de empresas: {empresas.length}</Text>
            <Text style={[styles.subheading, { color: block1Color }]}></Text>
          </View>
        </View>
      </View>
      <View style={[styles.block, { borderLeftColor: block2Color, shadowColor: block2Color }]}>
        <View style={styles.blockContent}>
          <Icon name="check-square-o" size={30} color={block2Color} style={styles.icon} />
          <View style={styles.blockText}>
            <Text style={[styles.heading, { color: block2Color }]}>Empresas ativas:  {numeroEmpresasAtivas}</Text>
            <Text style={[styles.subheading, { color: block2Color }]}></Text>
          </View>
        </View>
      </View>
      <View style={[styles.block, { borderLeftColor: block3Color, shadowColor: block3Color }]}>
        <View style={styles.blockContent}>
          <Icon name="star" size={30} color={block3Color} style={styles.icon} />
          <View style={styles.blockText}>
            <Text style={[styles.heading, { color: block3Color }]}>Total Filiais: {countFiliais} </Text>
            <Text style={[styles.subheading, { color: block3Color }]}></Text>
          </View>
        </View>
      </View>
      <View style={[styles.block, { borderLeftColor: block4Color, shadowColor: block4Color }]}>
        <View style={styles.blockContent}>
          <Icon name="clock-o" size={30} color={block4Color} style={styles.icon} />
          <View style={styles.blockText}>
            <Text style={[styles.heading, { color: block4Color }]}>Filias Ativas: </Text>
            <Text style={[styles.subheading, { color: block4Color }]}></Text>
          </View>
        </View>
      </View>

      <View style={styles.buttonContainer}>
        <View style={styles.switchContainer}>
          <Icon name={isDarkMode ? 'moon-o' : 'sun-o'} size={25} color={isDarkMode ? '#FFFFFF' : '#5A5A5A'} style={{ marginRight: 5 }} />
          <Switch value={isDarkMode} onValueChange={toggleDarkMode} />
        </View>
        <TouchableOpacity
          style={[
            styles.logoutButton,
            !isDarkMode ? styles.logoutButtonLight : styles.logoutButtonDark,
          ]}
          onPress={handleLogout}
        >
          <Icon
            name="sign-out"
            size={25}
            color={!isDarkMode ? '#5A5A5A' : '#fff'}
            style={styles.buttonIcon}
          />
          <Text
            style={[
              styles.logoutButtonText,
              !isDarkMode ? styles.logoutButtonTextLight : styles.logoutButtonTextDark,
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
    backgroundColor: '#ffff',
    justifyContent: 'center',
  },
  darkModeContainer: {
    backgroundColor: '#1E1E1E',
  },
  userContainer: {
    flexDirection: 'column',
    alignItems: 'center',
    justifyContent: 'center',
    marginBottom: 20,
  },
  userPhotoContainer: {
    marginBottom: 10,
  },
  userPhoto: {
    width: 100,
    height: 100,
    borderRadius: 50,
  },
  userName: {
    fontSize: 22,
    color: '#000000',
    fontWeight: 'bold',
    marginBottom: 10,
  },
  darkModeText: {
    color: '#FFFFFF',
  },
  title: {
    fontSize: 24,
    fontWeight: 'bold',
    marginBottom: 20,
  },
  block: {
    flexDirection: 'row',
    alignItems: 'center',
    justifyContent: 'flex-start',
    padding: 20,
    marginBottom: 20,
    borderRadius: 10,
    borderLeftWidth: 10,
    shadowOffset: { width: 0, height: 2 },
    shadowOpacity: 0.3,
    shadowRadius: 4,
    elevation: 5,
    backgroundColor: '#fff',
  },
  blockContent: {
    flexDirection: 'row',
    alignItems: 'center',
  },
  icon: {
    marginRight: 15,
  },
  blockText: {
    flexDirection: 'column',
  },
  heading: {
    fontSize: 18,
    fontWeight: 'bold',
  },
  subheading: {
    fontSize: 14,
    color: '#666',
  },
  buttonContainer: {
    flexDirection: 'row',
    alignItems: 'center',
    justifyContent: 'space-between',
  },
  switchContainer: {
    flexDirection: 'row',
    alignItems: 'center',
    marginRight: 10,
  },
  logoutButton: {
    flexDirection: 'row',
    alignItems: 'center',
    justifyContent: 'center',
    paddingVertical: 10,
    paddingHorizontal: 20,
    borderRadius: 10,
  },
  logoutButtonLight: {
    backgroundColor: '#fff',
  },
  logoutButtonDark: {
    backgroundColor: '#1E1E1E',
  },
  logoutButtonText: {
    fontSize: 16,
    marginLeft: 5,
  },
  logoutButtonTextLight: {
    color: '#5A5A5A',
  },
  logoutButtonTextDark: {
    color: '#fff',
  },
  buttonIcon: {
    marginRight: 5,
  },
});

export default DashboardEmpresa;

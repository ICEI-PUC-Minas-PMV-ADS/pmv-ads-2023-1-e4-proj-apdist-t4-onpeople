import React from 'react';
import { Image, View, StyleSheet } from 'react-native';

const StyledLogotipo = () => {
  return (
    <View style={styles.container}>
      <Image
        source={require('../Logo/img/logotipo.png')}
        style={styles.image}
      />
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'center',
    marginTop: '50%'
  },

  image: {
    width: 170,
    height: 170,
    alignSelf: 'center',
    marginBottom:20
  },
});

export default StyledLogotipo;

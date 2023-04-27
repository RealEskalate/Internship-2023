import 'package:flutter/material.dart';

double convertPixle(pixle, measurement, context) {
  if (measurement == "height") {
    double measure = pixle * 100 / 812;
    return MediaQuery.of(context).size.height * measure / 100;
  } else {
    double measure = pixle * 100 / 375;
    return MediaQuery.of(context).size.width * measure / 100;
  }
}

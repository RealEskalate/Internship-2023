import 'package:flutter/material.dart';
import 'package:intl/intl.dart';

import '../../../../core/utils/colors.dart';
import '../../domain/entities/city_weather.dart';

class WeatherDetail extends StatelessWidget {
  CityWeatherDetail detail;
  WeatherDetail(this.detail);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Color.fromRGBO(249, 245, 253, 1),
      appBar: AppBar(
        elevation: 0,
        shadowColor: Color.fromRGBO(249, 245, 253, 1),
        backgroundColor: Color.fromRGBO(249, 245, 253, 1),
        centerTitle: true,
        leading: IconButton(
          icon: Icon(
            Icons.arrow_back,
            color: primaryColor,
          ),
          onPressed: () {
            Navigator.pop(context);
          },
        ),
        title: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Text(detail.cityName, style: TextStyle(color: primaryColor)),
            Text(
              DateFormat('EEEE, MMM y').format(DateTime.now()),
              style: TextStyle(color: primaryColor, fontSize: 12),
            ),
          ],
        ),
        actions: [
          IconButton(
            icon: Icon(Icons.favorite_border, color: primaryColor),
            onPressed: () {},
          ),
        ],
      ),
      body: Column(
        children: [
          Expanded(
            flex: 1,
            child: Center(
              child: Image.network(
                detail.currentConditionImage,
                fit: BoxFit.cover,
              ),
            ),
          ),
          Padding(
            padding: const EdgeInsets.only(left: 16.0, bottom: 8.0),
            child: Row(
              children: [
                Text(detail.currentCondition,
                    style: TextStyle(
                        color: primaryAccentColor,
                        fontSize: 16,
                        fontWeight: FontWeight.w400)),
              ],
            ),
          ),
          Padding(
            padding: const EdgeInsets.only(left: 16.0, bottom: 16.0),
            child: Row(
              children: [
                Text(
                  '${detail.currentTempC}°',
                  style: TextStyle(fontSize: 32.0),
                ),
              ],
            ),
          ),
          Expanded(
            flex: 2,
            child: Container(
              decoration: BoxDecoration(
                color: primaryColor,
                borderRadius: BorderRadius.only(
                  topLeft: Radius.circular(10.0),
                  topRight: Radius.circular(10.0),
                ),
              ),
              child: ListView.builder(
                itemCount: 7,
                itemBuilder: (context, index) {
                  return ListTile(
                    title: Text(detail.forecastList[index].date,
                        style: TextStyle(color: whiteColor)),
                    trailing: Row(
                      mainAxisSize: MainAxisSize.min,
                      children: [
                        Text(
                          '${detail.forecastList[index].minTempC.toString()}°',
                          style: TextStyle(
                            fontSize: 18.0,
                            color: Colors.white,
                          ),
                        ),
                        SizedBox(width: 8.0),
                        Text(
                          '${detail.forecastList[index].maxTempC.toString()}°',
                          style: TextStyle(
                            fontSize: 18.0,
                            color: Colors.white,
                          ),
                        ),
                        SizedBox(width: 8.0),
                        Image.network(
                          detail.forecastList[index].image,
                        ),
                      ],
                    ),
                  );
                },
              ),
            ),
          ),
        ],
      ),
    );
  }
}

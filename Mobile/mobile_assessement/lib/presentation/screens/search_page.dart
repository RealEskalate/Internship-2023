import 'package:flutter/material.dart';
import 'package:mobile_assessement/presentation/bloc/bloc/weather_event.dart';
import 'package:mobile_assessement/presentation/bloc/bloc/weather_state.dart';
import 'package:mobile_assessement/presentation/widgets/broadcast_card.dart';


import '../../../../core/utils/colors.dart';
import '../bloc/bloc/weather_bloc.dart';

class SearchPage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Search Page'),
      ),
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: <Widget>[
            Padding(
              padding: EdgeInsets.all(20),
              child: TextField(
                decoration: InputDecoration(
                  hintText: 'Enter your search query',
                  border: OutlineInputBorder(
                    borderRadius: BorderRadius.circular(20),
                  ),
                ),
              ),
            ),
            ElevatedButton(
              onPressed: () {},
              child: Text('Search'),
            )
          ],
        ),
      ),
    );
  }
}
  

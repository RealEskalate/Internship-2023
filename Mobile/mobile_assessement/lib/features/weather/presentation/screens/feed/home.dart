import 'package:flutter/material.dart';
import 'package:mobile_assessement/features/weather/presentation/widget/get_start_button.dart';

import '../../../../../core/utils/ui_converter.dart';
import '../detail/city_detail.dart';

class HomePage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
        body: Container(
            padding: EdgeInsets.fromLTRB(
                UIConverter.getComponentWidth(context, 40),
                UIConverter.getComponentHeight(context, 50),
                UIConverter.getComponentWidth(context, 32),
                UIConverter.getComponentHeight(context, 20)),
            color: Color.fromARGB(255, 225, 225, 225),
            child: Column(
                crossAxisAlignment: CrossAxisAlignment.stretch,
                children: [
                  const Text(
                    'Choose a city',
                    style: TextStyle(
                      fontFamily: 'Roboto',
                      fontWeight: FontWeight.w700,
                      fontSize: 18,
                      color: Color(0xFF211772),
                    ),
                    textAlign: TextAlign.center,
                  ),
                  Container(
                    decoration: BoxDecoration(
                      color: Colors.white,
                      borderRadius: BorderRadius.circular(10),
                    ),
                    child: Row(
                      children: [
                        const Expanded(
                          child: TextField(
                            // controller: _searchController,
                            decoration: InputDecoration(
                              hintText: 'Search here',
                              border: InputBorder.none,
                            ),
                          ),
                        ),
                        IconButton(icon: Icon(Icons.search), onPressed: () {}),
                      ],
                    ),
                  ),
                  const Text(
                    'My Cities',
                    style: TextStyle(
                      fontFamily: 'Roboto',
                      fontWeight: FontWeight.w400,
                      fontSize: 16,
                      color: Color(0xFF211772),
                    ),
                  ),
                  Expanded(child: ListView.builder(
                      // itemCount: cities.length,
                      itemBuilder: (context, index) {
                    return InkWell(
                      onTap: () {
                        Navigator.push(
                          context,
                          MaterialPageRoute(
                              builder: (context) => DetailPage()),
                        );
                      },
                      child: Container(
                          margin: EdgeInsets.all(
                              UIConverter.getComponentWidth(context, 10)),
                          padding: EdgeInsets.all(
                              UIConverter.getComponentWidth(context, 20)),
                          decoration: BoxDecoration(
                            color: Colors.white,
                            borderRadius: BorderRadius.circular(10),
                          ),
                          child: Column(children: [
                            Row(
                              children: const [
                                Text(
                                  'New Mexico, USA: ',
                                  style: TextStyle(
                                    fontFamily: 'Roboto',
                                    fontWeight: FontWeight.w500,
                                    fontSize: 16,
                                    color: Color(0xFF211772),
                                  ),
                                ),
                                // SizedBox(width: UIConverter.getComponentWidth(context, width),),
                                SizedBox(width: 30),
                                Text(
                                  // cities[index]['temperature'],
                                  "39",
                                  style: TextStyle(
                                    fontFamily: 'Roboto',
                                    fontWeight: FontWeight.w500,
                                    fontSize: 24,
                                    color: Color(0xFF211772),
                                  ),
                                ),
                              ],
                            ),
                          ])),
                    );
                  }))
                ])));
  }
}

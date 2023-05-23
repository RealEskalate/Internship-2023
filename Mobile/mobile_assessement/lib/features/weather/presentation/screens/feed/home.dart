import 'package:flutter/material.dart';

import '../../../../../core/utils/ui_converter.dart';

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
            color: Colors.white,
            child: Column(
                crossAxisAlignment: CrossAxisAlignment.stretch,
                children: [
                  
          Positioned(
            width: 110,
            height: 21,
            left: 133,
            top: 56,
            child: Text(
              'Choose a city',
              style: TextStyle(
                fontFamily: 'Roboto',
                fontWeight: FontWeight.w700,
                fontSize: 18,
                color: Color(0xFF211772),
              ),
              textAlign: TextAlign.center,
            ),
          ),

          Container(
            decoration: BoxDecoration(
              color: Colors.white,
              borderRadius: BorderRadius.circular(10),
            ),
            child: Row(
              children: [
                Expanded(
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

          // Row(
          //   children: [
          //     Container(
          //       decoration: BoxDecoration(
          //         // color: Colors.white,
          //         borderRadius: BorderRadius.circular(10),
          //       ),
          //       child: Row(
          //         children: [
          //           Container(
          //             width: 20,
          //             height: 20,
          //             margin: EdgeInsets.all(5),
          //             decoration: BoxDecoration(
          //               border: Border.all(
          //                 // color: Color(0xFFD8D8D8),
          //                 width: 2,
          //               ),
          //             ),
          //           ),
          //           Expanded(
          //             child: Text(
          //               'Search a new city',
          //               style: TextStyle(
          //                 fontFamily: 'Roboto',
          //                 fontWeight: FontWeight.w400,
          //                 fontSize: 18,
          //                 // color: Color(0xFFD8D8D8),
          //               ),
          //             ),
          //           ),
          //         ],
          //       ),
          //     ),
          //     SizedBox(width: 10),
          //     Container(
          //       color: Color(0xFFFFBA25),
          //       child: TextButton(
          //         onPressed: () {
          //           // Handle button press
          //         },
          //         child: Text(
          //           'Search',
          //           style: TextStyle(
          //             fontFamily: 'Roboto',
          //             fontWeight: FontWeight.w500,
          //             fontSize: 16,
          //             // color: Colors.white,
          //           ),
          //         ),
          //       ),
          //     ),
          //   ],
          // ),
          Positioned(
            width: 95,
            height: 17,
            left: 17,
            top: 184,
            child: Text(
              'My Cities',
              style: TextStyle(
                fontFamily: 'Roboto',
                fontWeight: FontWeight.w400,
                fontSize: 16,
                color: Color(0xFF211772),
              ),
            ),
          ),
          Expanded(child: ListView.builder(
              // itemCount: cities.length,
              itemBuilder: (context, index) {
            return Container(
                margin: EdgeInsets.all(10),
                padding: EdgeInsets.all(10),
                decoration: BoxDecoration(
                  // color: Colors.white,
                  borderRadius: BorderRadius.circular(10),
                ),
                child: Column(children: [
                  Text(
                    // cities[index]['name'],
                    'name',
                    style: TextStyle(
                      fontFamily: 'Roboto',
                      fontWeight: FontWeight.w500,
                      fontSize: 16,
                      color: Color(0xFF575757),
                    ),
                  ),
                  SizedBox(height: 5),
                  Row(
                    children: [
                      Text(
                        'Temperature: ',
                        style: TextStyle(
                          fontFamily: 'Roboto',
                          fontWeight: FontWeight.w500,
                          fontSize: 16,
                          color: Color(0xFF211772),
                        ),
                      ),
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
                  SizedBox(height: 5),
                  Container(
                      width: 50,
                      height: 50,
                      decoration: BoxDecoration(
                          // color: Color(0xFFF1F1F2),
                          // borderRadius: BorderRadius
                          ))
                ]));
          }))
        ])));
  }
}

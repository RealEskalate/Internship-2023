import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutter/src/widgets/placeholder.dart';

class MyProfile extends StatelessWidget {
  const MyProfile({super.key});

  @override
  Widget build(BuildContext context) {
    return Padding(
              padding: EdgeInsets.only(right: 10, top: 5),
              child: Stack(
                children: [
                  CircleAvatar(
                      backgroundImage: AssetImage("assets/backgrd.jpg")),
                  Padding(
                    padding: EdgeInsets.only(left: 2.5, bottom: 12),
                    child: Column(
                        mainAxisAlignment: MainAxisAlignment.center,
                        children: [
                          Container(
                            decoration: BoxDecoration(
                                borderRadius: BorderRadius.circular(17),
                                border:
                                    Border.all(color: Colors.white, width: 2)),
                            width: 35,
                            height: 35,
                          )
                        ]),
                  ),
                ],
              ));
  }
}

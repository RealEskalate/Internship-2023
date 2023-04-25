import 'package:flutter/material.dart';
import 'package:flutter_svg/svg.dart';

class HomePage extends StatelessWidget {
  const HomePage({super.key});

  @override
  Widget build(BuildContext context) {
//  color
    return Scaffold(
      appBar: AppBar(
        elevation: 0,
        backgroundColor: Colors.white,
        leading: Stack(
          children: [
            Container(
                // child: SizedBox(
                //   height: 20,
                //   width: 20,
                //   child: SvgPicture.asset("menu.svg"),
                // ),
                ),
            Padding(
                padding: EdgeInsets.all(15),
                child: Container(
                    height: 35, width: 35, child: SvgPicture.asset("menu.svg")))
          ],
        ),
        title: Center(
            child: Text("Welcome  Back!",
                style: TextStyle(
                    color: Colors.black,
                    fontFamily: "Poppins",
                    fontSize: 25,
                    fontWeight: FontWeight.w800))),
        actions: [
          Padding(
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
              )),
        ],
      ),

      // ],
      // ),
    );
  }
}

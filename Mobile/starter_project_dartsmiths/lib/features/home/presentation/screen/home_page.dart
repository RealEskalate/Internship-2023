import 'package:flutter/material.dart';
import 'package:flutter_svg/svg.dart';


class HomePage extends StatelessWidget {
  const HomePage({super.key});

  @override
  Widget build(BuildContext context) {
    Color _color =
        Color(int.parse("#669AFF".substring(1, 7), radix: 16) + 0xFF000000);
    Color _color3 =
        Color(int.parse("#5E5F6F".substring(1, 7), radix: 16) + 0xFF000000);
    Color _color2 =
        Color(int.parse("#376AED".substring(1, 7), radix: 16) + 0xFF000000);
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
          // Container(
          //   child: Image.asset(
          //     'assets/backgrd.jpg',
          //     fit: BoxFit.cover,
          //   ),
          //   decoration: BoxDecoration(
          //     borderRadius: BorderRadius.circular(300),
          //   ),
          // ),
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
                            // /color: Color.fromARGB(255, 31, 30, 28),
                          )
                        ]),
                  ),
                ],
              )),
        ],
      ),
      body: Container(
        height: double.infinity,
        child: Column(
          children: [
            Padding(
              padding:
                  EdgeInsets.only(left: 15, right: 15, top: 20, bottom: 10),
              child: Container(
                child: Container(
                  decoration: BoxDecoration(
                    color: Colors.white,
                    borderRadius: BorderRadius.circular(10),
                  ),
                  child: Padding(
                    padding: EdgeInsets.only(left: 20),
                    child: Row(
                        mainAxisAlignment: MainAxisAlignment.spaceBetween,
                        children: [
                          Container(
                            child: Text(
                              "Search and article ..",
                              style: TextStyle(
                                  letterSpacing: 1,
                                  fontFamily: "Poppins",
                                  fontWeight: FontWeight.w100,
                                  fontSize: 16,
                                  color: Color(int.parse(
                                          "#9A9494".substring(1, 7),
                                          radix: 16) +
                                      0xFF000000)),
                            ),
                            color: Colors.white,
                          ),
                          Container(
                            decoration: BoxDecoration(
                                color: _color,
                                borderRadius: BorderRadius.circular(10)),
                            width: 55,
                            height: 60,
                            child: IconButton(
                                onPressed: () => {},
                                icon: Icon(
                                  size: 35,
                                  Icons.search_sharp,
                                  color: Colors.white,
                                )),
                          ),
                        ]),
                  ),
                  width: double.infinity,
                  height: 220,
                ),
                width: double.infinity,
                height: 50,
                decoration: BoxDecoration(
                  boxShadow: [
                    BoxShadow(
                      color: Colors.grey.withOpacity(0.3),
                      spreadRadius: 5,
                      blurRadius: 9,
                      offset: Offset(0, 9),
                    )
                  ],
                  borderRadius: BorderRadius.circular(10),
                  // border: Border.all(color: Colors.black, width: 2),
                ),
              ),
            ),
        
        ],
      ),),

      // ],
      // ),
    );
  }
}

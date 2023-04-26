import 'package:flutter/material.dart';


class StatusCard extends StatelessWidget {
  const StatusCard({super.key});

  @override
  Widget build(BuildContext context) {
    var screenWidth = MediaQuery.of(context);
    return Container(
        decoration: BoxDecoration(
          borderRadius: BorderRadius.all(Radius.circular(10)),
        ),
        // width: 280,
        height: screenWidth.size.height * 0.08,
        child: Stack(
          children: [
            Positioned(
              left: 50,
              top: 10,
              child: Row(children: [
                //second box starts here
                Container(
                  width: screenWidth.size.width * 0.16,
                  height: 50,
                  color: Color.fromARGB(255, 28, 92, 220),
                  child: Column(
                    mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                    children: const [
                      Text(
                        '250',
                        style: TextStyle(fontSize: 20, color: Colors.white),
                      ),
                      Padding(
                        padding: EdgeInsets.fromLTRB(0, 0, 0, 5),
                        child: Text('following',
                            style:
                                TextStyle(fontSize: 11, color: Colors.white)),
                      )
                    ],
                  ),
                ),

                //third box starts here
                Container(
                  width: screenWidth.size.width * 0.16,
                  height: 50,
                  decoration: const BoxDecoration(
                    color: Color.fromARGB(255, 28, 92, 220),
                    borderRadius: BorderRadius.only(
                      topRight: Radius.circular(10),
                      bottomRight: Radius.circular(10),
                    ),
                  ),
                  child: Column(
                    mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                    children: const [
                      Text(
                        '4.5k',
                        style: TextStyle(fontSize: 20, color: Colors.white),
                      ),
                      Padding(
                        padding: EdgeInsets.fromLTRB(0, 0, 0, 5),
                        child: Text('followers',
                            style:
                                TextStyle(fontSize: 11, color: Colors.white)),
                      )
                    ],
                  ),
                )
              ]),
            ),
            //second child of the stack
            Positioned(
              top: 10,
              left: -20,
              child: Container(
                width: 80,
                height: 50,
                decoration: const BoxDecoration(
                  color: Color.fromARGB(255, 40, 40, 192),
                  borderRadius: BorderRadius.all(Radius.circular(10)),
                ),
                child: Column(
                  mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                  children: const [
                    Text(
                      '52',
                      style: TextStyle(fontSize: 20, color: Colors.white),
                    ),
                    Padding(
                      padding: EdgeInsets.fromLTRB(0, 0, 0, 5),
                      child: Text('post',
                          style: TextStyle(fontSize: 11, color: Colors.white)),
                    )
                  ],
                ),
              ),
            ),
          ],
          //end of the inner stack
        )

        //end of the row
        );
  }
}

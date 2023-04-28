import 'package:flutter/material.dart';

class TitleBar extends StatelessWidget {
    TitleBar({super.key});
  
  TextStyle myTextStyle = const TextStyle(
    color: Colors.black,
    fontSize: 24.0,
    fontFamily: 'Poppins', 
  );

  @override
  Widget build(BuildContext context) {
    return  Container(
                margin:const EdgeInsets.fromLTRB(30, 20, 20, 20),
                height: 50,
                child: Stack(
                  children: [
                    Align(
                      alignment: Alignment.centerLeft,
                      child: Container(
                        decoration: const BoxDecoration(
                          color: Color.fromARGB(255, 240, 239, 238),
                          borderRadius:BorderRadius.all(Radius.circular(13)), 
                        ),
                        padding:const EdgeInsets.fromLTRB(1,1,1,1),
                        child: Material(
                          color: Colors.transparent,
                          borderRadius:const BorderRadius.all(Radius.circular(13)),
                          child: IconButton(
                            splashColor: const Color.fromARGB(255, 84, 83, 82),
                            splashRadius: 100,
                            onPressed: (){},
                            icon: const Icon(Icons.arrow_back_ios_new_sharp,color: Color.fromARGB(255, 131, 130, 129),size: 20, )),
                        )),
                    ),
                    Align(
                      alignment: Alignment.center,
                      child: Text('New Article',
                      style:myTextStyle,
                      
                      )
                    )
                  ]
                ) ,
              );
  }
}
import 'package:flutter/widgets.dart';
import 'package:flutter/material.dart';

class NavBar extends StatelessWidget {
  const NavBar({super.key});

  @override
  Widget build(BuildContext context) {
    return Row(
          mainAxisAlignment: MainAxisAlignment.spaceEvenly,
          children: [
            Expanded(
              child: Container(
                // color: Colors.grey,
                child: Center(child: Text('For You')),
              ),
            ),
            Expanded(
              child: Container(
                // color: Colors.grey,
                child: Center(child: Text('Scholarships')),
              ),
            ),
            Expanded(
              child: Container(
                // color: Colors.grey,
                child: Center(child: Text('Resources')),
              ),
            ),
            Expanded(
              child: Container(
                // color: Colors.grey,
                child: Center(child: Text('Cumpus Life')),
              ),
            ),
          ],
        );
  }
}
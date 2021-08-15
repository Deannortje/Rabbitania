import 'package:flutter/material.dart';
import 'package:font_awesome_flutter/font_awesome_flutter.dart';
import 'package:frontend/src/models/util_model.dart';
import 'package:frontend/src/screens/Booking/bookingAdminHomeScreen.dart';
import 'package:frontend/src/widgets/Booking/bookingAppBar.dart';
import 'package:frontend/src/widgets/Booking/bookingButton.dart';
import 'package:frontend/src/widgets/Booking/bookingDayButton.dart';
import 'package:flutter_svg/svg.dart';
import 'package:frontend/src/widgets/Booking/bookingDayScreenButton.dart';
import 'package:frontend/src/widgets/Booking/bookingDayText.dart';
import 'package:frontend/src/widgets/NavigationBar/actionBar.dart';
import 'package:frontend/src/widgets/NavigationBar/navigationbar.dart';

class BookingDayScreen extends StatefulWidget {
  final displayText;
  final bookText = 'Book';

  BookingDayScreen(this.displayText);
  @override
  _BookingDayState createState() => _BookingDayState();
}

class _BookingDayState extends State<BookingDayScreen> {
  var displayText;
  final utilModel = UtilModel();
  determineDisplayText() {
    switch (widget.displayText) {
      case 'M':
        this.displayText = 'Monday';
        break;
      case 'Tu':
        this.displayText = 'Tuesday';
        break;
      case 'W':
        this.displayText = 'Wednesday';
        break;
      case 'Th':
        this.displayText = 'Thursday';
        break;
      case 'F':
        this.displayText = 'Friday';
        break;
    }
  }

  initState() {
    super.initState();
    determineDisplayText();
  }

  @override
  Widget build(BuildContext context) => Scaffold(
        floatingActionButton: FancyFab(
          heroTag: "BookingDayScreenPage",
          numberOfItems: 1,
          icon1: Icons.shield_outlined,
          onPressed1: () {
            UtilModel.route(() => BookingAdminScreen(), context);
          },
          icon2: Icons.shield_outlined,
          onPressed2: () {},
          icon3: Icons.edit,
          onPressed3: () {},
        ),
        bottomNavigationBar: bnb(context),
        appBar: AppBar(
          centerTitle: true,
          toolbarHeight: 220,
          elevation: 1,
          automaticallyImplyLeading: false,
          backgroundColor: Colors.transparent,
          flexibleSpace: Column(
            children: <Widget>[
              Container(
                child: Padding(
                  padding: EdgeInsets.only(
                      top: MediaQuery.of(context).size.height * 0.07,
                      bottom: 10),
                ),
              ),
              Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: <Widget>[
                  Container(
                    margin: const EdgeInsets.only(bottom: 10),
                    child: Text(
                      'Day Booking',
                      style: TextStyle(
                        fontSize: 35,
                        color: Color.fromRGBO(172, 255, 79, 1),
                      ),
                    ),
                  ),
                ],
              ),
              Container(
                child: Padding(
                  padding: EdgeInsets.only(bottom: 10),
                ),
              ),
              Row(
                mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                children: <Widget>[
                  this.displayText == 'Monday'
                      ? new BookingDayButton(
                          'M',
                          Color.fromRGBO(63, 63, 63, 1),
                        ) //if true
                      : new BookingDayButton('M', Colors.transparent), //else
                  this.displayText == 'Tuesday'
                      ? new BookingDayButton(
                          'Tu',
                          Color.fromRGBO(63, 63, 63, 1),
                        ) //if true
                      : new BookingDayButton('Tu', Colors.transparent), //
                  this.displayText == 'Wednesday'
                      ? new BookingDayButton(
                          'W',
                          Color.fromRGBO(63, 63, 63, 1),
                        ) //if true
                      : new BookingDayButton('W', Colors.transparent),
                  this.displayText == 'Thursday'
                      ? new BookingDayButton(
                          'Th',
                          Color.fromRGBO(63, 63, 63, 1),
                        ) //if true
                      : new BookingDayButton('Th', Colors.transparent),
                  this.displayText == 'Friday'
                      ? new BookingDayButton(
                          'F',
                          Color.fromRGBO(63, 63, 63, 1),
                        ) //if true
                      : new BookingDayButton('F', Colors.transparent),
                ],
              ),
              Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: <Widget>[
                  Container(
                    margin: const EdgeInsets.only(top: 10),
                    child: Text(
                      this.displayText,
                      style: TextStyle(
                        fontSize: 28,
                        color: Color.fromRGBO(172, 255, 79, 1),
                      ),
                    ),
                  ),
                ],
              ),
            ],
          ),
        ),
        backgroundColor: Color.fromRGBO(33, 33, 33, 1),
        body: Center(
          child: Stack(
            children: <Widget>[
              SvgPicture.string(
                utilModel.svg_background,
                fit: BoxFit.contain,
              ),
              Column(
                //crossAxisAlignment: CrossAxisAlignment.center,
                children: <Widget>[
                  Container(
                    margin: const EdgeInsets.only(top: 50),
                    child: BookingDayText(
                        'Morning', this.displayText, widget.bookText),
                  ),
                  Padding(
                    padding: const EdgeInsets.only(top: 50),
                  ),
                ],
              ),
            ],
          ),
        ),
      );
}

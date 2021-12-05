"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var testing_1 = require("@angular/core/testing");
var admin_guard_1 = require("./admin.guard");
describe('AdminGuard', function () {
    beforeEach(function () {
        testing_1.TestBed.configureTestingModule({
            providers: [admin_guard_1.AdminGuard]
        });
    });
    it('should ...', (0, testing_1.inject)([admin_guard_1.AdminGuard], function (guard) {
        expect(guard).toBeTruthy();
    }));
});
//# sourceMappingURL=admin.guard.spec.js.map